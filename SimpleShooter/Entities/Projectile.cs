using SFML.System;
using SimpleShooter.Enums;
using SFML.Graphics;
using SimpleShooter.Components;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Entities;

public class Projectile : Entity
{
    Entity? Entity { get; set; }

    public Projectile(int projectileId, float initialX, float initialY, Vector2f direction)
        : base(projectileId)
    {
        Components[typeof(MovementComponent)] = new MovementComponent { Entity = Entity, Speed = 10.0f, Direction = direction };
        Components[typeof(PositionComponent)] = new PositionComponent { Entity = Entity, X = initialX, Y = initialY, EntityType = EntityTypes.Projectile };
        Components[typeof(ColliderComponent)] = new ColliderComponent { Entity = Entity, Bounds = new FloatRect(initialX, initialY, 2, 2) };
    }
}
