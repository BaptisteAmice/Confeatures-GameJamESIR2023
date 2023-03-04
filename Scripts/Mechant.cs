using Godot;
using System;

public class Mechant : KinematicBody2D {
    private bool touchable=false;

    void toucheMechant () {
        touchable=true;
    }

    void pasToucheMechant () {
        touchable=false;
    }

    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionJustPressed("interect") && touchable) {
			AnimatedSprite sprite=GetNode<AnimatedSprite>("BonhommeSpriteMarche");
            sprite.Rotation=0;
            Vector2 position=this.Position;
            position.x=0;
            position.y=14;

            sprite.Position=position;
		}
    }
        
}
