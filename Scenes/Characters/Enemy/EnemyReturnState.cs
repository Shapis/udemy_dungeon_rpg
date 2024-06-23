using Godot;

public partial class EnemyReturnState : EnemyState
{

    public override void _Ready()
    {
        base._Ready();

        destination = GetPointGlobalPosition(0);
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode is not null)
        {
            if (characterNode.AgentNode.IsNavigationFinished())
            {
                characterNode.StateMachineNode.SwitchStates<EnemyPatrolState>();
                return;
            }

            Move();

        }
    }

    protected override void EnterState()
    {
        characterNode.AnimationPlayerNode.Play(AC.EnemyAnimation.Move.ToString());

        characterNode.AgentNode.TargetPosition = destination;
    }


}
