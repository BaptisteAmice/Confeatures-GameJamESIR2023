using Godot;
using System;

public class BonhommeSpriteMarche : AnimatedSprite {
    public int mort=0;
    public void SetAnimation() {
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            this.Playing=true;
            this.Visible=true;
        } else {
            this.Visible=false;
        }

        if (Input.IsActionPressed("move_right")) {
            this.FlipH=true;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=false;
        }

        if (Input.IsActionPressed("attack")) {
            this.Visible=false;
        }
    }

    public override void _PhysicsProcess(float delta) {
        /*if (Input.IsActionPressed("suicide")) {Death();} 
        else if (mort==1) {
            Revivre();
        }*/
        SetAnimation();
    }
}
