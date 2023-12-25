using SFML.Graphics;
using SimpleShooter.Components;
using SimpleShooter.Entities.Base;
using SimpleShooter.Enums;

namespace SimpleShooter.Entities;

public class Enemy : Entity
{
    Entity? Entity { get; set; }

    public Enemy(int enemyId, float initialX, float initialY, int initialHealth)
        : base(enemyId)
    {
        Components[typeof(MovementComponent)] = new MovementComponent { Entity = Entity, Speed = 3.5f };
        Components[typeof(VitalsComponent)] = new VitalsComponent { Entity = Entity, Health = initialHealth };
        Components[typeof(PositionComponent)] = new PositionComponent { Entity = Entity, X = initialX, Y = initialY, EntityType = EntityTypes.Enemy };
        Components[typeof(ColliderComponent)] = new ColliderComponent { Entity = Entity, Bounds = new FloatRect(initialX, initialY, 5, 5) };
    }
}
