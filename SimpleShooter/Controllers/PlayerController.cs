using SFML.Window;
using SimpleShooter.Components;
using SimpleShooter.Entities;

namespace SimpleShooter.Controllers;

public class PlayerController
{
    private readonly Player _player;

    public PlayerController(Player player)
    {
        _player = player;
    }

    public void HandleKeyPressed(KeyEventArgs e)
    {
        if (_player.Components.TryGetValue(typeof(KeyPressedComponent), out var keyPressedComponentObj))
        {
            var keyPressedComponent = (KeyPressedComponent)keyPressedComponentObj;
            keyPressedComponent.IsKeyPressed = true;
            keyPressedComponent.LastKeyPressed = e.Code;
        }
    }

    public void HandleKeyReleased(KeyEventArgs e)
    {
        if (_player.Components.TryGetValue(typeof(KeyPressedComponent), out var keyPressedComponentObj))
        {
            var keyPressedComponent = (KeyPressedComponent)keyPressedComponentObj;
            keyPressedComponent.IsKeyPressed = false;
        }
    }
}
