using Godot;
using System;

public class Mechant : KinematicBody2D {
    private bool touchable=false;

    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionJustPressed("interect")) {
			//TryBreak();
		}
    }
        
}
