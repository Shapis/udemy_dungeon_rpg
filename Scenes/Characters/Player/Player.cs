using Godot;

public partial class Player : Character
{

    public sealed override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(AC.InputDirection.MoveLeft.ToString(), AC.InputDirection.MoveRight.ToString(), AC.InputDirection.MoveForward.ToString(), AC.InputDirection.MoveBackward.ToString());
    }
}
