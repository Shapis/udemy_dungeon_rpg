using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    private int pointIndex;
    protected override void EnterState()
    {

        characterNode!.AnimationPlayerNode!.Play(AC.EnemyAnimation.Move.ToString());
        pointIndex = 1;
        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;

        characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
    }


    public sealed override void _PhysicsProcess(double delta)
    {
        Move();
    }

    private void HandleNavigationFinished()
    {
        pointIndex = Mathf.Wrap(
            pointIndex + 1, 0, characterNode.pathNode.Curve.PointCount
        );

        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
    }
}
