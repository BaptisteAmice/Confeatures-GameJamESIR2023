using Godot;
using System;


public class BonhommeSpriteAttaque : AnimatedSprite {

    private bool isAttack = false;
    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionPressed("attack") && isAttack == false) {
            this.Playing=true;
            this.Visible=true;
            isAttack = true;
        } else {
            this.Playing=false;

        }

        /*if (Input.IsActionPressed("move_right")) {
            this.FlipH=true;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=false;
        }*/

        if (Input.IsActionPressed("attack") != true) {
            isAttack = false;
            this.Visible=false;
        }
            

    }
}
