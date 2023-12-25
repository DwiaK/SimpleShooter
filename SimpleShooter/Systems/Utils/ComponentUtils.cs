using SimpleShooter.Components;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Systems.Utils;

public static class ComponentUtils
{
    public static MovementComponent GetMovementComponent(Entity entity)
    {
        if (entity.Components.TryGetValue(typeof(MovementComponent), out var movementComponentObj))
            return (MovementComponent)movementComponentObj;

        var newMovementComponent = new MovementComponent();
        entity.Components[typeof(MovementComponent)] = newMovementComponent;
        return newMovementComponent;
    }

    public static PositionComponent GetPositionComponent(Entity entity)
    {
        if (entity.Components.TryGetValue(typeof(PositionComponent), out var positionComponentObj))
            return (PositionComponent)positionComponentObj;

        var newPositionComponent = new PositionComponent();
        entity.Components[typeof(PositionComponent)] = newPositionComponent;
        return newPositionComponent;
    }

    public static CooldownComponent GetCooldownComponent(Entity entity)
    {
        if (entity.Components.TryGetValue(typeof(CooldownComponent), out var cooldownComponentObj))
            return (CooldownComponent)cooldownComponentObj;

        var newCooldownComponent = new CooldownComponent();
        entity.Components[typeof(CooldownComponent)] = newCooldownComponent;
        return newCooldownComponent;
    }

    public static ColliderComponent GetColliderComponent(Entity entity)
    {
        if (entity.Components.TryGetValue(typeof(ColliderComponent), out var colliderComponentObj))
            return (ColliderComponent)colliderComponentObj;

        var newColliderComponent = new ColliderComponent();
        entity.Components[typeof(ColliderComponent)] = newColliderComponent;
        return newColliderComponent;
    }
}
