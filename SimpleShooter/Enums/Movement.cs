using System.ComponentModel;

namespace SimpleShooter.Enums;

public enum Movement
{
    [Description("Up")]
    Up,

    [Description("Down")]
    Down,

    [Description("Left")]
    Left,

    [Description("Right")]
    Right,
}