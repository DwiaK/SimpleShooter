using SFML.Graphics;
using SimpleShooter.Components.Base;
using SimpleShooter.Enums;

namespace SimpleShooter.Components;

public class ColliderComponent : Component
{
    private FloatRect _bounds;
    public FloatRect Bounds
    {
        get => _bounds;
        set => _bounds = value;
    }

    public EntityTypes EntityType { get; set; }

    public void UpdateBounds(PositionComponent positionComponent)
    {
        _bounds.Left = positionComponent.X;
        _bounds.Top = positionComponent.Y;
    }
}
