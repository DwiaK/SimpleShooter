using SFML.Window;
using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class KeyPressedComponent : Component
{
    public bool IsKeyPressed { get; set; }

    public Keyboard.Key LastKeyPressed { get; set; }
}
