using System.ComponentModel;

namespace SimpleShooter.Enums;

public enum EntityTypes
{
    [Description("Player")]
    Player,

    [Description("Enemy")]
    Enemy,

    [Description("Projectile")]
    Projectile,
}