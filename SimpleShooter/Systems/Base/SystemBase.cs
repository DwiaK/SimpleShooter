using SFML.Graphics;
using SimpleShooter.Entities.Base;

namespace SimpleShooter.Systems.Base;

public class SystemBase
{
    public virtual void Update(List<Entity> entities, RenderWindow window) { }
}
