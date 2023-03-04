using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    public Vector2 velocity=new Vector2();

    private const int speed=200;
    private const int gravity=3000;
    private const int jump=-10000;

    public void GetInput(float delta) {
        velocity = new Vector2();
        AnimatedSprite sprite = GetNode<AnimatedSprite>("BonhommeSprite");

        if (Input.IsActionPressed("move_right")) {
            velocity.x += speed;
        }

        if (Input.IsActionPressed("move_left")) {
            velocity.x -= speed;
        }

        if(IsOnFloor()) {
            if(Input.IsActionPressed("move_up"))
                velocity.y += jump;
        }
    }

    public override void _PhysicsProcess(float delta) {
        GetInput(delta);
        velocity.y+= delta*gravity;
        velocity = MoveAndSlide(velocity, new Vector2(0,-1));
    }
}