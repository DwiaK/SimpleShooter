using SimpleShooter.Enums;
using SFML.Graphics;
using SimpleShooter.Components;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Entities;

public class Player : Entity
{
    public Entity? Entity { get; }

    public Player(int playerId, float initialX, float initialY)
        : base(playerId)
    {
        Components[typeof(MovementComponent)] = new MovementComponent { Entity = Entity, Speed = 5.0f };
        Components[typeof(PositionComponent)] = new PositionComponent { Entity = Entity, X = initialX, Y = initialY, EntityType = EntityTypes.Player };
        Components[typeof(CooldownComponent)] = new CooldownComponent { Entity = Entity, CooldownTime = 1.0f, TimeSinceLastShot = 0.0f };
        Components[typeof(ColliderComponent)] = new ColliderComponent { Entity = Entity, Bounds = new FloatRect(initialX, initialY, 5, 5) };
    }
}
