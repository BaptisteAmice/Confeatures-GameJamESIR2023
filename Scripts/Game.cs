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

        //connects signal to method for piece
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
            //connects signal to method for drapeau
            drapeau.Connect("BreakDrapeau", this, "BriseDrapeau");
        }

        //get first drapeau
        checkpoint = (Drapeau)drapeauNodes[0];
        //cget its animated sprite and set it to 0
        checkpoint.GetNode<AnimatedSprite>("AnimatedSprite").Frame = 0;

    }

    public void teleportToCheckpoint() {
        //get checkpoint position
        Vector2 checkpointPosition = checkpoint.Position;
        //y-10 to avoid teleporting in the ground
        checkpointPosition.y -= 10;
        //teleport Bonhomme to checkpoint position
        bonhomme.Position = checkpointPosition;
    }

    public void BriseDrapeau(Drapeau drapeau) {
        //checkpoint becomes value next to drapeau in drapeauNodes
        int index = drapeauNodes.IndexOf(drapeau);
        if (index < drapeauNodes.Count - 1)
        {
            checkpoint = (Drapeau)drapeauNodes[index + 1];
        }
        else
        {
            checkpoint = (Drapeau)drapeauNodes[0];
        }
        //hide the drapeau
        drapeau.Hide();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
