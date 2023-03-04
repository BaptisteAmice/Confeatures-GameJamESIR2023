using Godot;
using System;

public class Piece : Area2D
{
    private bool isCollected = false;

    [Signal]
    public delegate Piece PieceTouched();
    

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
        if (body is mouvementBonhomme && !isCollected)
        {
            //set to sprite 1
            animatedSprite.Frame = 1;
            //emit signal to parent
            
            isCollected = true;

            //A REVOIR
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
