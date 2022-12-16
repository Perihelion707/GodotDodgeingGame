using Godot;
using System;

public class Paddle : Area2D
{
	private const int MoveSpeed = 300;

	// All three of these change for each paddle.
	private string _up;
	private string _down;
	private string _left;
	private string _right;

	public override void _Ready()
	{
		string name = Name.ToLower();
		_up = name + "_move_up";
		_down = name + "_move_down";
		_left = name + "_move_left";
		_right = name + "_move_right";
		//_ballDir = name == "Player" ? 1 : -1;
	}

	public override void _Process(float delta)
	{
		// Move up and down based on input.
		
		float Yinput = Input.GetActionStrength(_down) - Input.GetActionStrength(_up);
		float Xinput = Input.GetActionStrength(_right) - Input.GetActionStrength(_left);
		Vector2 position = Position; // Required so that we can modify position.y.
		position += new Vector2(Xinput * MoveSpeed * delta, Yinput * MoveSpeed * delta);
		position.y = Mathf.Clamp(position.y, 20, GetViewportRect().Size.y - 20);
		position.x = Mathf.Clamp(position.x, 5, GetViewportRect().Size.x - 5);
		Position = position;
	}
}
