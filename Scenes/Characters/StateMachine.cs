using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node? currentState;
    [Export] private Node[]? states;

    public sealed override void _Ready()
    {
        currentState!.Notification(5001);
    }

    public void SwitchStates<T>()
    {
        Node? newState = null;

        if (states is not null)
        {
            foreach (Node state in states)
            {
                if (state is T)
                {
                    newState = state;
                }

            }
        }

        if (newState is not null)
        {
            currentState = newState;
            currentState.Notification(5001);
        }
    }
}
