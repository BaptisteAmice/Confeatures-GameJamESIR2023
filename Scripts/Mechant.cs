using Godot;
using System;

public class Mechant : KinematicBody2D {
    [Export] public int touchable=0;

    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionJustPressed("interect")) {
			//TryBreak();
		}
    }
        
}
