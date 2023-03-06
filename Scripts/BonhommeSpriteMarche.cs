using Godot;
using System;

public class BonhommeSpriteMarche : AnimatedSprite {

    public void SetAnimation() {
        Vector2 position=this.Position;
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            this.Playing=true;
            this.Visible=true;
        } else {
            this.Visible=false;
        }

        /*if (Input.IsActionPressed("move_right")) {
            this.FlipH=true;
            position.x=-6;
            this.Position=position;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=false;
            position.x=0;
            this.Position=position;
        }   */

        if (Input.IsActionPressed("attack")) {
            this.Visible=false;
        }
    }

    public override void _PhysicsProcess(float delta) {
        SetAnimation();
    }
}
