using Godot;
using System;

public class Warning : Node
{
	[Export] public  PackedScene childScene;
	private Timer timer;
	public override void _Ready()
	{
		// Create a Delay node and set its wait time to 1 second
		timer = GetNodeOrNull<Timer>("Timer");
		if (timer == null)
		{
			// Timer node not found, create it programmatically
			timer = new Timer();
			timer.WaitTime = 1.0f; // Wait 1 second
			timer.Connect("timeout", this, nameof(instantiate_child));
			AddChild(timer); // Add the Timer node as a child of the TimerChildSceneExample node
		}
		timer.Start();
	}

	// Function to instantiate the child scene
	public void instantiate_child()
	{
		// Instantiate the child scene and add it as a child of this node
		Node2D child = (Node2D)childScene.Instance();
		AddChild(child);

	}
}
