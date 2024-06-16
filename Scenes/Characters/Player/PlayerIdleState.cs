using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode?.direction != Vector2.Zero)
        {
            characterNode!.StateMachineNode?.SwitchStates<PlayerMoveState>();
        }
    }



    public sealed override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(AC.PlayerAnimation.Dash.ToString()))
        {
            characterNode!.StateMachineNode!.SwitchStates<PlayerDashState>();
        }
    }

    protected override void EnterState(AC.PlayerAnimation playerAnimation)
    {
        base.EnterState(AC.PlayerAnimation.Idle);
    }
}
