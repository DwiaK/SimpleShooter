using SimpleShooter.Components.Base;
using SimpleShooter.Enums;

namespace SimpleShooter.Components;

public class PositionComponent : Component
{
    public float X { get; set; }
    public float Y { get; set; }

    public EntityTypes EntityType { get; set; }

    public void Move(float deltaX, float deltaY)
    {
        X += deltaX;
        Y += deltaY;
    }
}
