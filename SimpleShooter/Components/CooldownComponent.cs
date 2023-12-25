using SimpleShooter.Components.Base;

namespace SimpleShooter.Components;

public class CooldownComponent : Component
{
    public float CooldownTime { get; set; }
    public float TimeSinceLastShot { get; set; }
}
