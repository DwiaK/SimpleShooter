using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleShooter.Components;
using SimpleShooter.Entities;
using SimpleShooter.Entities.Base;
using SimpleShooter.Enums;
using SimpleShooter.Systems.Base;

namespace SimpleShooter.Systems.Utils;

public class KeyInputSystem : SystemBase
{
    public override void Update(List<Entity> entities, RenderWindow window)
    {
        foreach (var entity in entities)
        {
            if (entity is Player)
            {
                var movementComponent = ComponentUtils.GetMovementComponent(entity);
                var positionComponent = ComponentUtils.GetPositionComponent(entity);

                if (Keyboard.IsKeyPressed(Keyboard.Key.W)) Move(positionComponent, movementComponent, Movement.Up);
                if (Keyboard.IsKeyPressed(Keyboard.Key.S)) Move(positionComponent, movementComponent, Movement.Down);
                if (Keyboard.IsKeyPressed(Keyboard.Key.A)) Move(positionComponent, movementComponent, Movement.Left);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D)) Move(positionComponent, movementComponent, Movement.Right);

                PositionUtils.UpdatePosition(entity, movementComponent);
            }
        }
    }

    public void Move(PositionComponent positionComponent, MovementComponent movementComponent, Movement movementType)
    {
        Vector2f vectorPosition = new Vector2f();

        switch (movementType)
        {
            // Normal
            case Movement.Up:
                vectorPosition.Y -= movementComponent.Speed;
                positionComponent.Y += vectorPosition.Y;
                break;

            case Movement.Down:
                vectorPosition.Y += movementComponent.Speed;
                positionComponent.Y += vectorPosition.Y;
                break;

            case Movement.Left:
                vectorPosition.X -= movementComponent.Speed;
                positionComponent.X += vectorPosition.X;
                break;

            case Movement.Right:
                vectorPosition.X += movementComponent.Speed;
                positionComponent.X += vectorPosition.X;
                break;
        }

        // Normalizar (Valor Diagonal (se x=1 e y=1; xy=2))
        var movControl = new Vector2f(vectorPosition.X, vectorPosition.Y);

        if (vectorPosition.X != 0 && vectorPosition.Y != 0)
            movControl *= 1.58f;
        //movControl /= MathF.Sqrt(10f);

        //Console.WriteLine($"X: {PosX} Y: {PosY}");
        //Console.WriteLine($"X: {vectorPosition.X} Y: {vectorPosition.Y}");
        //Console.WriteLine($"{movControl}");
    }
}
