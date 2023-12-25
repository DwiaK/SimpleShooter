using SFML.Graphics;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Systems.Base;
using SimpleShooter.Systems.Utils;

namespace SimpleShooter.Systems.GameLogic;

public class EnemyMovementSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities)
        {
            if (entity is Enemy)
            {
                var movementComponent = ComponentUtils.GetMovementComponent(entity);
                var positionComponent = ComponentUtils.GetPositionComponent(entity);
            }
        }
    }
}
