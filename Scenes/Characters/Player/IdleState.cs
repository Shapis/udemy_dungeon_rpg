using Godot;
using System;

public partial class IdleState : Node
{
    private Player? characterNode;
    public sealed override void _Ready()
    {
        characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode?.direction != Vector2.Zero)
        {
            characterNode!.stateMachine?.SwitchStates<MoveState>();
        }
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {

            characterNode!.animationPlayer!.Play(AC.PlayerAnimation.Idle.ToString());
            SetPhysicsProcess(true);
        }
    }
}
