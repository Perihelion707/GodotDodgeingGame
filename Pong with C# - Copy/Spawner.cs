using Godot;
using System;

public class Spawner : Node
{
	[Export]
	public PackedScene SceneToInstantiate; // Drag and drop the scene to be instantiated into this property in the editor

	[Export]
	public int MinX = 0; // Minimum X position in the viewport

	[Export]
	public int MaxX = 100; // Maximum X position in the viewport

	[Export]
	public int MinY = 0; // Minimum Y position in the viewport

	[Export]
	public int MaxY = 100; // Maximum Y position in the viewport

	[Export]
	public int MinAngle = 0; // Minimum angle in degrees

	[Export]
	public int MaxAngle = 360; // Maximum angle in degrees

	private Timer _timer;
	private Random _random;

	public override void _Ready()
	{
		// Initialize the random number generator
		_random = new Random();

		_timer = GetNodeOrNull<Timer>("Timer");
		if (_timer == null)
		{
			// Timer node not found, create it programmatically
			_timer = new Timer();
			_timer.WaitTime = 5.0f; // Wait 1 second
			_timer.Connect("timeout", this, nameof(_OnTimeTimerTimeout));
			AddChild(_timer); // Add the Timer node as a child of the TimerChildSceneExample node
		}
		_timer.Start();
	}

	public void _OnTimeTimerTimeout()
	{
		// Decrease the wait time for the timer by a small amount each time it times out
		_timer.WaitTime *= 0.9f;

		// Clamp the wait time to a minimum value
		_timer.WaitTime = Math.Max(_timer.WaitTime, 0.1f);

		// Instantiate the scene at a random position and angle
		Node2D node = (Node2D)SceneToInstantiate.Instance();
		node.Transform = new Transform2D
			(Mathf.Deg2Rad(_random.Next(MinAngle, MaxAngle)),
			new Vector2(_random.Next(MinX, MaxX), _random.Next(MinY, MaxY)));

		AddChild(node);

		// Restart the timer
		_timer.Start();
	}
}

