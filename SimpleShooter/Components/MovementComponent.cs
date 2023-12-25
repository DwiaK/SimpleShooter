using SFML.System;
using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class MovementComponent : Component
{
    public float Speed { get; set; } = 5.0f;
    public Vector2f Direction { get; set; }

    public override void Update()
    {
        // Atualize a posição com base na velocidade e direção
        if (Entity.Components.TryGetValue(typeof(PositionComponent), out var positionComponentObj))
        {
            var positionComponent = (PositionComponent)positionComponentObj;
            positionComponent.X += Speed * Direction.X;
            positionComponent.Y += Speed * Direction.Y;
        }
    }
}
