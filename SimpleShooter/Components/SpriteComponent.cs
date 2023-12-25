using SFML.Graphics;
using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class SpriteComponent : Component
{
    public CircleShape sprite = new CircleShape();
}
