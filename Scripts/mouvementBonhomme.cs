using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    [Export] public int speed = 200;

    public Vector2 velocity=new Vector2();
    public int sens;
    public int gravity=5000;
    

    public void GetInput() {
        velocity = new Vector2();
        AnimatedSprite sprite = GetNode<AnimatedSprite>("BonhommeSprite");

        if (Input.IsActionPressed("move_right")) {
            velocity.x += 1;
            sprite.FlipH=false;
        }

        if (Input.IsActionPressed("move_left")) {
            velocity.x -= 1;
            sprite.FlipH=true;
        }

        /*if (Input.IsActionPressed("move_down")) {
            velocity.y += 1;
        }*/

        if (Input.IsActionPressed("move_up")) {
            velocity.y -= 1;
        }

        velocity = velocity.Normalized() * speed;
    }

    public void SetSprite() {
        AnimatedSprite sprite = GetNode<AnimatedSprite>("BonhommeSprite");

        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            sprite.Playing=true;
        } else {
            sprite.Playing=false;
        }
    }

    public override void _PhysicsProcess(float delta) {
        GetInput();
        SetSprite();
        velocity.y+= delta*gravity;
        velocity = MoveAndSlide(velocity);
    }
}