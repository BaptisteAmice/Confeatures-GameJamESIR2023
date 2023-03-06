using Godot;
using System;

public class PilierTombant : Sprite
{
    [Export]
    public int fallingSpeed = 100;
    [Export]
    public int rotateSpeed = 10;


    public bool falling = false;
    public void _on_AreaTrigger_body_entered(Node body)
    {
        if (body is mouvementBonhomme)
        {
            falling = true;
        }
    }

    public override void _PhysicsProcess(float delta)
    {
        if (falling)
        {

            RotationDegrees +=  rotateSpeed * delta;
            Position += new Vector2(0, fallingSpeed) * delta;
        }
    }

}
