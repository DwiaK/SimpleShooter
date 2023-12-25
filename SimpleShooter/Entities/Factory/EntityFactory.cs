using SFML.Graphics;
using SFML.System;
using SimpleShooter.Entities;

namespace SimpleShooter.Entities.Factory;

public static class EntityFactory
{
    public static Player CreatePlayer(int playerId, float initialX, float initialY) =>
        new Player(playerId, initialX, initialY);

    public static Enemy CreateEnemy(int enemyId, float initialX, float initialY, int initialHealth) =>
        new Enemy(enemyId, initialX, initialY, initialHealth);

    public static Projectile CreateProjectile(int projectileId, float initialX, float initialY, Vector2f direction) =>
        new Projectile(projectileId, initialX, initialY, direction);
}
