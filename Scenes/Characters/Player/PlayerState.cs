using Godot;

public abstract partial class PlayerState : Node
{
    protected Player? characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == (int)AC.NotificationType.EnterState)
        {
            EnterState(AC.PlayerAnimation.Idle);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == (int)AC.NotificationType.ExitState)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }

    }

    protected virtual void EnterState(AC.PlayerAnimation playerAnimation)
    {
        characterNode!.AnimationPlayerNode!.Play(playerAnimation.ToString());
    }
}