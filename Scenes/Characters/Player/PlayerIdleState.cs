using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player? characterNode;
    public sealed override void _Ready()
    {
        characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode?.direction != Vector2.Zero)
        {
            characterNode!.stateMachine?.SwitchStates<PlayerMoveState>();
        }
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {

            characterNode!.animationPlayer!.Play(AC.PlayerAnimation.Idle.ToString());
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }

    }

    public sealed override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(AC.PlayerAnimation.Dash.ToString()))
        {
            characterNode.stateMachine.SwitchStates<PlayerDashState>();
        }
    }
}
