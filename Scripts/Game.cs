using Godot;
using System;
using System.Collections;

public class Game : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    //get drapeau nodes
    private Godot.Collections.Array drapeauNodes;
    private Drapeau checkpoint;
    private mouvementBonhomme bonhomme;

    private int piecesNumber;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //get Bonhomme node
        bonhomme = GetNode<mouvementBonhomme>("Bonhomme");

        Drapeaux_setup();

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
            //teleport Bonhomme to checkpoint position
            teleportToCheckpoint();
        }
    }

    public void Drapeaux_setup() {
        //get drapeau nodes
        drapeauNodes = GetNode("Drapeaux").GetChildren();
        //sho all drapeau names
        foreach (Node drapeau in drapeauNodes)
        {
            GD.Print(drapeau.Name);
        }

        //get first drapeau
        checkpoint = (Drapeau)drapeauNodes[0];

    }

    public void teleportToCheckpoint() {
        //get checkpoint position
        Vector2 checkpointPosition = checkpoint.Position;
        //y-10 to avoid teleporting in the ground
        checkpointPosition.y -= 10;
        //teleport Bonhomme to checkpoint position
        bonhomme.Position = checkpointPosition;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
