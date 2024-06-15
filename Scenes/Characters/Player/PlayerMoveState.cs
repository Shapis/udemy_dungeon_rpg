using Godot;
using System;

public partial class PlayerMoveState : Node
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
        if (characterNode?.direction == Vector2.Zero)
        {
            characterNode!.stateMachine?.SwitchStates<PlayerIdleState>();
            return;
        }

        characterNode!.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= 5;

        characterNode.MoveAndSlide();

        characterNode.Flip();
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            characterNode!.animationPlayer!.Play(AC.PlayerAnimation.Move.ToString());
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

