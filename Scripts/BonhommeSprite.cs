using Godot;
using System;

public class BonhommeSprite : AnimatedSprite {
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
    }

    public void Death() {
        this.FlipV=false;
        //this.SelfModulate(1, 0.29, 0.29, 1);
        mort=1;
    }

    public void Revivre() {
        this.FlipV=true;
        //base.SelfModulate(1, 1, 1, 1);
        mort=0;
    }


    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionPressed("suicide")) {Death();} 
        else if (mort==1) {
            Revivre();
        }
        SetAnimation();
    }
}
