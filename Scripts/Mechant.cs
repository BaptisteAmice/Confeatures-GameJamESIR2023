using Godot;
using System;

public class Mechant : KinematicBody2D {
<<<<<<< HEAD
    [Export] public int touchable=0;

    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionJustPressed("interect")) {
			TryBreak();
		}
    }
=======
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
>>>>>>> cebf070c37c881b5c9e81d9ec3e5075c7f3945d4
}
