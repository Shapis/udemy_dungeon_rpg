using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    protected override void EnterState()
    {
        characterNode!.AnimationPlayerNode!.Play(AC.EnemyAnimation.Move.ToString());

        destination = GetPointGlobalPosition(1);
        characterNode.AgentNode.TargetPosition = destination;
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
