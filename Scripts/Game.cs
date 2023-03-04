using Godot;
using System;
using System.Collections;

public class Game : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";



    private int piecesNumber;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {


        


        //piece number equals to number of Piece node
        piecesNumber = GetNode("Piece").GetChildCount();
        GD.Print(piecesNumber);

        //connect signal to method
        GetNode("Piece").Connect("PieceTouched", this, "PieceTouched");
    }

    public void PieceTouched()
    {
        //decrease piece number
        piecesNumber--;
        GD.Print(piecesNumber);

        //if no more piece, load next level
        if (piecesNumber == 0)
        {
            GD.Print("Next level");
        }
    }

        public void _on_DeadZone_body_entered(object body) {
        if (body is mouvementBonhomme) {
            GD.Print("DeadZone touché");
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
