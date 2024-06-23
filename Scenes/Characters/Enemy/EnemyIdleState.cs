using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        characterNode!.AnimationPlayerNode!.Play(AC.EnemyAnimation.Idle.ToString());
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        characterNode.StateMachineNode.SwitchStates<EnemyReturnState>();
    }
}
