using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node? currentState;
    [Export] private Node[]? states;

    public sealed override void _Ready()
    {
        currentState!.Notification((int)AC.NotificationType.EnterState);
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
            currentState!.Notification((int)AC.NotificationType.ExitState);
            currentState = newState;
            currentState.Notification((int)AC.NotificationType.EnterState);
        }
    }
}
