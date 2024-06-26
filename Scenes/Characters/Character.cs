using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public Sprite3D? Sprite3DNode { get; private set; }
    [Export] public AnimationPlayer? AnimationPlayerNode { get; private set; }
    [Export] public StateMachine? StateMachineNode { get; private set; }

    [ExportGroup("AI Nodes")]
    [Export] public Path3D? pathNode { get; private set; }
    [Export] public NavigationAgent3D? AgentNode { get; private set; }

    public Vector2 direction = new();
    public void Flip()
    {
        if (Velocity.X != 0)
        {
            Sprite3DNode!.FlipH = Velocity.X < 0;
        }
    }

}