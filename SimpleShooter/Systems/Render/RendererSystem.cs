using SFML.Graphics;
using SFML.System;
using SimpleShooter.Components;
using SimpleShooter.Entities.Base;
using SimpleShooter.Enums;
using SimpleShooter.Systems.Base;

namespace SimpleShooter.Systems.Render;

public class RendererSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities)
        {
            if (entity.Components.TryGetValue(typeof(PositionComponent), out var positionComponentObj))
            {
                var positionComponent = (PositionComponent)positionComponentObj;

                CircleShape shape = positionComponent.EntityType switch
                {
                    EntityTypes.Player => DrawPlayer(positionComponent),
                    EntityTypes.Enemy => DrawEnemy(positionComponent),
                    EntityTypes.Projectile => DrawProjectile(positionComponent),
                    _ => throw new NotImplementedException()
                };

                window.Draw(shape);
            }
        }
    }

    #region Entities
    private CircleShape DrawPlayer(PositionComponent positionComponent) =>
        new CircleShape(10)
        {
            Position = new Vector2f(positionComponent.X, positionComponent.Y),
            FillColor = Color.Green
        };

    private CircleShape DrawEnemy(PositionComponent positionComponent) =>
        new CircleShape(10)
        {
            Position = new Vector2f(positionComponent.X, positionComponent.Y),
            FillColor = Color.Red
        };

    private CircleShape DrawProjectile(PositionComponent positionComponent) =>
        new CircleShape(2)
        {
            Position = new Vector2f(positionComponent.X, positionComponent.Y),
            FillColor = Color.Yellow
        };
    #endregion
}
