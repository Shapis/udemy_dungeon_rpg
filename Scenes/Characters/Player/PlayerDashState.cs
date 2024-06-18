using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] Timer? dashTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 10;
    public override void _Ready()
    {
        base._Ready();
        dashTimerNode!.Timeout += HandleDashTimeout;
    }


    public sealed override void _PhysicsProcess(double delta)
    {

        characterNode!.MoveAndSlide();

        characterNode.Flip();
    }

    protected override void EnterState()
    {
        characterNode!.AnimationPlayerNode!.Play(AC.PlayerAnimation.Dash.ToString());

        characterNode!.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);

        if (characterNode.Velocity == Vector3.Zero)
        {
            characterNode.Velocity = characterNode.Sprite3DNode!.FlipH ? Vector3.Left : Vector3.Right;
        }

        characterNode.Velocity *= speed;
        dashTimerNode!.Start();
    }

    private void HandleDashTimeout()
    {
        characterNode!.Velocity = Vector3.Zero;
        characterNode!.StateMachineNode!.SwitchStates<PlayerIdleState>();
    }
}
