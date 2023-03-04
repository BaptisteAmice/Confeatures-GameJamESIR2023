using Godot;
using System;

public class pauseBonhomme : Sprite {
    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            this.Visible=false;
        } else {
            this.Visible=true;
        }

         if (Input.IsActionPressed("move_right")) {
            this.FlipH=true;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=false;
        }

        if (Input.IsActionPressed("attack")) {
            this.Visible=false;
        } else {
            this.Visible=true;
        }
    }


}
