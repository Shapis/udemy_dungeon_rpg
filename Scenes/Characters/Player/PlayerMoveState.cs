using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

    [Export(PropertyHint.Range, "0,10,0.1")] private float speed = 5;
    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode?.direction == Vector2.Zero)
        {
            characterNode!.StateMachineNode?.SwitchStates<PlayerIdleState>();
            return;
        }

        characterNode!.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= speed;

        characterNode.MoveAndSlide();

        characterNode.Flip();
    }

    public sealed override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(AC.PlayerAnimation.Dash.ToString()))
        {
            characterNode!.StateMachineNode!.SwitchStates<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        characterNode!.AnimationPlayerNode!.Play(AC.PlayerAnimation.Move.ToString());
    }
}

