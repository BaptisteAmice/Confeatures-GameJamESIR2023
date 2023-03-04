using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    public Vector2 velocity=new Vector2();

    private const int speed=200;
    private const int gravity=5000;
    private const int jump=-9000;

    public void GetInput(float delta) {
        velocity=new Vector2();
        AnimatedSprite sprite=GetNode<AnimatedSprite>("BonhommeSprite");
        Timer timer=GetNode<Timer>("TimerJump");

        if (Input.IsActionPressed("move_right")) {
            velocity.x+=speed;
        }

        if (Input.IsActionPressed("move_left")) {
            velocity.x-=speed;
        }

        if(IsOnFloor() || (timer.TimeLeft>0)) {
            if (!(timer.TimeLeft>0)) {
                timer.Start((float)0.35);
            }
            if(Input.IsActionPressed("move_up"))
                velocity.y += delta*jump;
        } else {
            velocity.y+= delta*gravity;
        }
    }

    public override void _PhysicsProcess(float delta) {
        GetInput(delta);
        velocity = MoveAndSlide(velocity, new Vector2(0,-1));
    }
}