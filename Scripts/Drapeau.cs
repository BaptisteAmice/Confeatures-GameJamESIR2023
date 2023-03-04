using Godot;
using System;

public class Drapeau : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void _on_Drapeau_body_entered(object body)
    {
        if (body is mouvementBonhomme)
        {
            GD.Print("Drapeau touché");
        }
    }



//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
