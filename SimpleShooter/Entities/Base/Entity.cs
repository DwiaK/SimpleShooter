using SimpleShooter.Components.Base;

namespace SimpleShooter.Entities.Base;

public class Entity
{
    public int Id { get; }

    public Dictionary<Type, Component> Components { get; } = new Dictionary<Type, Component>();

    public Entity(int id) => Id = id;

    public T GetComponent<T>() where T : Component
    {
        Type componentType = typeof(T);
        if (Components.TryGetValue(componentType, out var component))
        {
            return (T)component;
        }
        return null;
    }

    public bool HasComponent(Type componentType)
    {
        return Components.ContainsKey(componentType);
    }
}
