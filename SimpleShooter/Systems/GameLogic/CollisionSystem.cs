using SFML.Graphics;
using SimpleShooter.Enums;
using SimpleShooter.Components;
using SimpleShooter.Systems.Base;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Systems.GameLogic;

public class CollisionSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities)
        {
            if (entity.HasComponent(typeof(ColliderComponent)) &&
                entity.HasComponent(typeof(PositionComponent)))
            {
                var colliderComponent = entity.GetComponent<ColliderComponent>();
                var positionComponent = entity.GetComponent<PositionComponent>();

                // Atualizar boundingBox
                colliderComponent.UpdateBounds(positionComponent);

                CheckCollisions(entity, entities);
            }
        }
    }

    private void CheckCollisions(Entity entity, List<Entity> entities)
    {
        ColliderComponent colliderA = entity.GetComponent<ColliderComponent>();

        foreach (var otherEntity in entities)
        {
            if (entity != otherEntity && otherEntity.Components.ContainsKey(typeof(ColliderComponent)))
            {
                ColliderComponent colliderB = otherEntity.GetComponent<ColliderComponent>();

                if (CanCollide(colliderA, colliderB) && Collides(colliderA, colliderB))
                {
                    HandleCollision(entity, otherEntity);
                }
            }
        }
    }

    private bool Collides(ColliderComponent colliderA, ColliderComponent colliderB) =>
        colliderA.Bounds.Intersects(colliderB.Bounds);

    private bool CanCollide(ColliderComponent colliderA, ColliderComponent colliderB)
    {
        if (colliderA.EntityType == EntityTypes.Enemy &&
            colliderB.EntityType == EntityTypes.Projectile ||
            colliderA.EntityType == EntityTypes.Projectile &&
            colliderB.EntityType == EntityTypes.Enemy)
            return true;
        else
            return false;
    }

    private void HandleCollision(Entity entityA, Entity entityB)
    {
        // Lógica de tratamento de colisão
        Console.WriteLine($"Collision between {entityA.Id} and {entityB.Id}");
    }
}
