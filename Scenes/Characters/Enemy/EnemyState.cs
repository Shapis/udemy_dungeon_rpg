using Godot;

public abstract partial class EnemyState : CharacterState
{

    protected Vector3 destination;

    protected Vector3 GetPointGlobalPosition(int index)
    {
        Vector3 localPosition = characterNode!.pathNode!.Curve.GetPointPosition(index);
        Vector3 globalPosition = characterNode!.pathNode!.GlobalPosition;
        return localPosition + globalPosition;
    }

    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);

        characterNode.MoveAndSlide();
    }
}