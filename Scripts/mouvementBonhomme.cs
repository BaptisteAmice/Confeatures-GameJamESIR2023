using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    [Export] public int speed = 200;

    public Vector2 velocity=new Vector2();
    public int sens;

    public void GetInput() {
        velocity = new Vector2();

        if (Input.IsActionPressed("move_right"))
            velocity.x += 1;
            sens=0;

        if (Input.IsActionPressed("move_left"))
            velocity.x -= 1;
            sens=1;

        if (Input.IsActionPressed("move_down"))
            velocity.y += 1;

        if (Input.IsActionPressed("move_up"))
            velocity.y -= 1;

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta) {
        GetInput();
        Sprite sprite = GetNode<Sprite>("BonhommeSprite");
        sprite.SetFlipH(sens);
        velocity = MoveAndSlide(velocity);
    }
}