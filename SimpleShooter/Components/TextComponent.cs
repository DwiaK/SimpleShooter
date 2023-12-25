using SFML.Graphics;
using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class TextComponent : Component
{
    public float X { get; set; }
    public float Y { get; set; }
    public string? Text { get; set; }
    public Font? Font { get; set; }
    public Color Color { get; set; }
}
