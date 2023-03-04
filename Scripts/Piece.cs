using Godot;
using System;

public class Piece : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    AnimatedSprite animatedSprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        //set to sprite 0
        animatedSprite.Frame = 0;
    }

    public void _on_Piece_body_entered(object body)
    {
        if (body is mouvementBonhomme)
        {
            //set to sprite 1
            animatedSprite.Frame = 1;
            GD.Print("Piece touché");
        }
    }

    public void _on_Piece_body_exited(object body)
    {
        if (body is mouvementBonhomme)
        {
            GD.Print("Piece quitté");
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
