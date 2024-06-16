using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public Sprite3D? Sprite3DNode { get; private set; }
    [Export] public AnimationPlayer? AnimationPlayerNode { get; private set; }

    [Export] public StateMachine? StateMachineNode { get; private set; }

    public Vector2 direction = new();

    public sealed override void _Ready()
    {
    }

    public sealed override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(AC.InputDirection.MoveLeft.ToString(), AC.InputDirection.MoveRight.ToString(), AC.InputDirection.MoveForward.ToString(), AC.InputDirection.MoveBackward.ToString());
    }

    public void Flip()
    {
        if (Velocity.X != 0)
        {
            Sprite3DNode!.FlipH = Velocity.X < 0;
        }
    }
}
