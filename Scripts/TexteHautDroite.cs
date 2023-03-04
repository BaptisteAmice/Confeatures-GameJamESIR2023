using Godot;
using System;

public class TexteHautDroite : Node2D
{
    private mouvementBonhomme bonhomme;
    float differenceX;
    float differenceY;

    public override void _Ready()
    {
        //get Bonhomme node
        mouvementBonhomme bonhomme = GetNode<mouvementBonhomme>("../Bonhomme");

        //get difference between Bonhomme and TexteHautDroite
        differenceX = bonhomme.Position.x - Position.x;
        differenceY = bonhomme.Position.y - Position.y;
        
    }
    //move to 
    public override void _Process(float delta)
    {
        Position = new Vector2(bonhomme.Position.x - differenceX, bonhomme.Position.y - differenceY);
        
    }
}
