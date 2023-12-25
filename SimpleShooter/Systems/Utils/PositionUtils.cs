using SimpleShooter.Components;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Systems.Utils;

public static class PositionUtils
{
    public static void UpdatePosition(Entity entity, MovementComponent movementComponent)
    {
        if (entity.Components.TryGetValue(typeof(PositionComponent), out var positionComponentObj))
        {
            var positionComponent = (PositionComponent)positionComponentObj;
            positionComponent.X += movementComponent.Speed * movementComponent.Direction.X;
            positionComponent.Y += movementComponent.Speed * movementComponent.Direction.Y;
        }
    }
}
