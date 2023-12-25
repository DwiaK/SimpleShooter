using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleShooter.Components;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Enums;
using SimpleShooter.Systems.Base;
using SimpleShooter.Systems.Utils;

namespace SimpleShooter.Systems.GameLogic;

public class ProjectileSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities.ToList())
        {
            if (entity is Projectile)
            {
                var movementComponent = ComponentUtils.GetMovementComponent(entity);
                var positionComponent = ComponentUtils.GetPositionComponent(entity);

                // Log para verificar a posição e direção dos projéteis
                Console.WriteLine($"Projectile Position: ({positionComponent.X}, {positionComponent.Y}), Direction: ({movementComponent.Direction.X}, {movementComponent.Direction.Y})");

                // Lógica para controlar o movimento do projétil
                PositionUtils.UpdatePosition(entity, movementComponent);

                // Renderiza o projétil (substitua isso pela lógica real de renderização)
                var projectileShape = new CircleShape(2)
                {
                    Position = new Vector2f(positionComponent.X, positionComponent.Y),
                    FillColor = Color.Yellow
                };

                window.Draw(projectileShape);

                // Lógica para remover o projétil se estiver fora da tela
                if (IsProjectileOutsideWindow(positionComponent, window))
                {
                    // Log para verificar a posição e direção da destruição dos projéteis
                    entities.Remove(entity);
                    Console.WriteLine($"Projectile Destroyed in Position: ({positionComponent.X}, {positionComponent.Y}), Direction: ({movementComponent.Direction.X}, {movementComponent.Direction.Y})");
                }

            }
        }
    }

    private bool IsProjectileOutsideWindow(PositionComponent positionComponent, RenderWindow window)
    {
        // Verifica se o projétil está fora dos limites da tela
        return positionComponent.X < 0 || positionComponent.X > window.Size.X ||
               positionComponent.Y < 0 || positionComponent.Y > window.Size.Y;
    }
}
