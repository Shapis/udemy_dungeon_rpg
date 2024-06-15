using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public Sprite3D? sprite3D;
    [Export] public AnimationPlayer? animationPlayer;

    [Export] public StateMachine? stateMachine;

    public Vector2 direction = new();

    public sealed override void _Ready()
    {
    }

    public sealed override void _Process(double delta)
    {
        Flip();
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();


    }

    public sealed override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(AC.InputDirection.MoveLeft.ToString(), AC.InputDirection.MoveRight.ToString(), AC.InputDirection.MoveForward.ToString(), AC.InputDirection.MoveBackward.ToString());
    }

    private void Flip()
    {
        if (Velocity.X != 0)
        {
            sprite3D!.FlipH = Velocity.X < 0;
        }
    }
}
