using SFML.Graphics.Glsl;
using SFML.System;
using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class TransformComponent : Component
{
    public Vector2i position = new Vector2i();
    public Vector2i scale = new Vector2i();
}
