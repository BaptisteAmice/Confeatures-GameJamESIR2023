using Godot;
using System;

public class Piece : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Piece_body_entered(object body)
    {
        if (body is mouvementBonhomme)
        {
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
