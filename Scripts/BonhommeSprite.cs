using Godot;
using System;

public class BonhommeSprite : AnimatedSprite {
    public void SetAnimation() {
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            this.Playing=true;
        } else {
            this.Playing=false;
        }

        if (Input.IsActionPressed("move_right")) {
            this.FlipH=false;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=true;
        }
    }

    public override void _PhysicsProcess(float delta) {
        SetAnimation();
    }
}
