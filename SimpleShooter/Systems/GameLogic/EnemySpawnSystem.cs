using SFML.Graphics;
using SimpleShooter.Components;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Entities.Factory;
using SimpleShooter.Systems.Base;
using System.Runtime.CompilerServices;

namespace SimpleShooter.Systems.GameLogic;

public class EnemySpawnSystem : SystemBase
{
    private int _enemiesSpawned = 0;

    public override void Update(List<Entity> entities, RenderWindow window)
    {
        // Verifica se todos os Inimigos foram destruídos
        if (entities.Count(entity => entity is Enemy) == 0)
            Spawn(entities);
    }

    public void Spawn(List<Entity> entities)
    {
        // Temporário
        const int enemiesToSpawn = 10;
        const int initialHealth = 100;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            float spawnX = GetRandomSpawnCoordinate();
            float spawnY = GetRandomSpawnCoordinate();

            var enemy = EntityFactory.CreateEnemy(_enemiesSpawned++, spawnX, spawnY, initialHealth);
            entities.Add(enemy);

            // Atualizar as coordenadas da bounding box com base na posição da entidade
            var colliderComponent = enemy.GetComponent<ColliderComponent>();
            var positionComponent = enemy.GetComponent<PositionComponent>();
            colliderComponent.UpdateBounds(positionComponent);
        }
    }

    private float GetRandomSpawnCoordinate() =>
        new Random().Next(600);
}
