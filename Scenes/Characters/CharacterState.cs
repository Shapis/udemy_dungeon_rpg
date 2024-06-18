using System;
using Godot;

public abstract partial class CharacterState : Node
{
    protected Character? characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<Character>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == (int)AC.NotificationType.EnterState)
        {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == (int)AC.NotificationType.ExitState)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }

    }

    protected virtual void EnterState()
    {

    }
}