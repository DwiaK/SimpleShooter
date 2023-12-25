using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleShooter.Components;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Entities.Factory;
using SimpleShooter.Systems.Base;

namespace SimpleShooter.Systems.Utils;

public class MouseClickSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities.ToList())
        {
            if (entity is Player)
            {
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    // Posição do mouse
                    var mousePosition = Mouse.GetPosition(window);

                    // Converter a posição do mouse para coordenadas gerais
                    var generalMousePosition = window.MapPixelToCoords(mousePosition);

                    var player = entities.Find(entity => entity is Player);

                    if (player != null)
                    {
                        var playerPosition = (PositionComponent)player.Components[typeof(PositionComponent)];

                        var direction = new Vector2f(generalMousePosition.X - playerPosition.X, generalMousePosition.Y - playerPosition.Y);
                        direction = Normalize(direction);

                        var projectile = EntityFactory.CreateProjectile(entities.Count, playerPosition.X, playerPosition.Y, direction);
                        entities.Add(projectile);
                    }
                }
            }
        }
    }

    private Vector2f Normalize(Vector2f direction)
    {
        // Calcular Normalização do vetor de direção
        float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
        if (length != 0)
        {
            direction.X /= length;
            direction.Y /= length;
        }

        return direction;
    }
}
