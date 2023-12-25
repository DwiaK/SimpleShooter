using SimpleShooter.Entities.Base;

namespace SimpleShooter.Components.Base;

public class Component
{
    public Entity? Entity { get; set; }

    public virtual void Update() { }
}
