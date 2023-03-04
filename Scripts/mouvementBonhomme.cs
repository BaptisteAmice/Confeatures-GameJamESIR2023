using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    public Vector2 velocity=new Vector2();

    private const int speed=200;
    private const int gravity=8000;
    private const float jump=-20000;

    private const float timerDelay=0.15f;

    public void GetInput(float delta) {
        velocity=new Vector2();
        AnimatedSprite sprite=GetNode<AnimatedSprite>("BonhommeSprite");
        Timer timer=GetNode<Timer>("TimerJump");

        if (Input.IsActionPressed("move_right") ||Input.IsActionPressed("move_left")) {
            velocity.x+=speed*((Input.IsActionPressed("move_right") ? 1 : 0) - ((Input.IsActionPressed("move_left") ? 1 : 0)));
        }

        if ( IsOnFloor() && Input.IsActionPressed("move_up")) {
            timer.Start(timerDelay);
        }
        if (timer.TimeLeft>0) {
             velocity.y+=delta*jump;
        } else {
                velocity.y+=delta*gravity;
        }
    }

    public override void _PhysicsProcess(float delta) {
        GetInput(delta);
        velocity = MoveAndSlide(velocity, new Vector2(0,-1));
    }
}