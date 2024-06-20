using Godot;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPosition = characterNode!.pathNode!.Curve.GetPointPosition(0);
        Vector3 globalPosition = characterNode!.pathNode!.GlobalPosition;
        destination = localPosition + globalPosition;
    }

    public sealed override void _PhysicsProcess(double delta)
    {
        if (characterNode is not null)
        {
            if (characterNode.GlobalPosition == destination)
            {
                GD.Print("Reached destination!");
                return;
            }
            characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);

            characterNode.MoveAndSlide();
        }
    }

    protected override void EnterState()
    {
        characterNode!.AnimationPlayerNode!.Play(AC.EnemyAnimation.Move.ToString());
    }


}
