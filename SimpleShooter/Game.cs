using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleShooter.Controllers;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Entities.Factory;
using SimpleShooter.Systems.GameLogic;
using SimpleShooter.Systems.Render;
using SimpleShooter.Systems.Utils;

namespace SimpleShooter;

public class Game
{
    // Janela
    private readonly RenderWindow _window;

    // Fonte
    private Font _font;

    // Fps
    private Text _fpsText;

    // Entidades
    private readonly List<Entity> _entities = new List<Entity>();
    private readonly Player _player;

    // Sistemas
    private readonly KeyInputSystem _keyPressedSystem;
    private readonly MovementSystem _movementSystem;
    private readonly RendererSystem _rendererSystem;
    private readonly EnemySpawnSystem _enemySpawnSystem;
    private readonly ProjectileSystem _projectileSystem;
    private readonly MouseClickSystem _mouseClickSystem;
    private readonly CollisionSystem _collisionSystem;

    // Controladores
    private readonly PlayerController _playerController;

    // Fps
    public static short _fps;

    public Game()
    {
        // Configurações da Janela
        _window = new RenderWindow(new VideoMode(800, 600), "Simple Shooter", Styles.Default);

        // Fps
        _font = new Font("c:/Windows/Fonts/arial.ttf");
        _fpsText = new Text("Fps: 0", _font, 10);
        _fpsText.Position = new Vector2f(10, 10);

        // Inicializar Jogador
        _player = CreatePlayer(_entities.Select(x => x.Id + 1).FirstOrDefault(), 400, 300);
        _entities.Add(_player);

        // Iniciar Controladores
        _playerController = new PlayerController(_player);

        // Eventos de Janela
        _window.KeyPressed += (sender, e) => _playerController.HandleKeyPressed(e);
        _window.KeyReleased += (sender, e) => _playerController.HandleKeyReleased(e);

        // Sistemas
        _keyPressedSystem = new KeyInputSystem();
        _movementSystem = new MovementSystem();
        _rendererSystem = new RendererSystem();
        _enemySpawnSystem = new EnemySpawnSystem();
        _projectileSystem = new ProjectileSystem();
        _mouseClickSystem = new MouseClickSystem();
        _collisionSystem = new CollisionSystem();
    }

    #region Antigo Run com Cálculo de Framerate manual
    //public void Run()
    //{
    //    var t1000Timer = 0;
    //    var t30Timer = 0;
    //    short fps = 0;

    //    WindowEvents(_window);

    //    while (_window.IsOpen)
    //    {
    //        _window.Clear();

    //        // Events
    //        _window.DispatchEvents();

    //        // FPS
    //        if (t1000Timer < Environment.TickCount)
    //        {
    //            _fps = fps;
    //            fps = 0;
    //            t1000Timer = Environment.TickCount + 1000;
    //        }
    //        else
    //            fps++;

    //        _fpsText.DisplayedString = $"FPS: {_fps}";
    //        _window.Draw(_fpsText);

    //        // TickCount
    //        if (t30Timer < Environment.TickCount)
    //        {
    //            _window.Draw(_fpsText);

    //            // Atualizações Sistemas
    //            UpdateSystems();

    //            // Reiniciar a Contagem
    //            t30Timer = Environment.TickCount + 30;
    //        }
    //    }
    //}
    #endregion

    public void Run()
    {
        Clock clock = new Clock();
        _window.SetFramerateLimit(30);

        WindowEvents(_window);

        while (_window.IsOpen)
        {
            // Limpa a tela
            _window.Clear();

            // Eventos
            _window.DispatchEvents();

            // FPS
            float currentTime = clock.Restart().AsSeconds();
            float fps = 1.0f / (currentTime);

            _fpsText.DisplayedString = $"FPS: {Math.Round(fps, 0)}";
            _window.Draw(_fpsText);

            // Atualizações Sistemas
            UpdateSystems();
        }
    }

    private void UpdateSystems()
    {
        // Sistemas
        _movementSystem.Update(_entities, _window);
        _enemySpawnSystem.Update(_entities, _window);
        _projectileSystem.Update(_entities, _window);
        _collisionSystem.Update(_entities, _window);

        // Renderer
        _rendererSystem.Update(_entities, _window);

        // Utils
        _keyPressedSystem.Update(_entities, _window);
        _mouseClickSystem.Update(_entities, _window);

        _window.Display();
    }

    private void WindowEvents(RenderWindow window)
    {
        window.Closed += (obj, e) =>
        {
            window.Close();
        };

        window.KeyPressed += (sender, e) =>
        {
            Window window = (Window)sender;

            if (e.Code == Keyboard.Key.Escape)
                window.Close();
        };
    }

    private Player CreatePlayer(int playerId, float initialX, float initialY) =>
        EntityFactory.CreatePlayer(playerId, initialX, initialY);
}
