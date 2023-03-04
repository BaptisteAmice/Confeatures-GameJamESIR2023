using Godot;
using System;

public class BonhommeSpriteAttaque : AnimatedSprite {
    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionPressed("attack")) {
            this.Playing=true;
            this.Visible=true;
        } else {
            this.Playing=false;
            this.Visible=false;
        }
    }
}
