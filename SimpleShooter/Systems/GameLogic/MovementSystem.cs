using SFML.Graphics;
using SimpleShooter.Components;
using SimpleShooter.Systems.Base;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Systems.GameLogic;

public class MovementSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities)
        {
            // Verifica se a entidade possui um componente de movimento
            if (entity.Components.TryGetValue(typeof(MovementComponent), out var movementComponentObj))
            {
                var movementComponent = (MovementComponent)movementComponentObj;
                UpdateEntityPosition(entity, movementComponent);
            }
        }
    }

    private void UpdateEntityPosition(Entity entity, MovementComponent movementComponent)
    {
        // Atualiza a posição da entidade com base na velocidade e direção
        if (entity.Components.TryGetValue(typeof(PositionComponent), out var positionComponentObj))
        {
            var positionComponent = (PositionComponent)positionComponentObj;
            positionComponent.X += movementComponent.Speed * movementComponent.Direction.X;
            positionComponent.Y += movementComponent.Speed * movementComponent.Direction.Y;
        }
    }
}
