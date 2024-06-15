using Godot;
using System;

public partial class PlayerDashState : Node
{
    [Export] Timer? dashTimerNode;
    [Export] private float speed = 10;
    private Player? characterNode;
    public sealed override void _Ready()
    {
        characterNode = GetOwner<Player>();
        dashTimerNode!.Timeout += HandleDashTimeout;
        SetPhysicsProcess(false);
    }


    public sealed override void _PhysicsProcess(double delta)
    {

        characterNode!.MoveAndSlide();

        characterNode.Flip();
    }

    public sealed override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            characterNode!.animationPlayer!.Play(AC.PlayerAnimation.Dash.ToString());
            SetPhysicsProcess(true);
            characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);

            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = characterNode.sprite3DNode!.FlipH ? Vector3.Left : Vector3.Right;
            }

            characterNode.Velocity *= speed;
            dashTimerNode!.Start();
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }

    }

    private void HandleDashTimeout()
    {
        characterNode!.Velocity = Vector3.Zero;
        characterNode!.stateMachine!.SwitchStates<PlayerIdleState>();
    }
}
