using Godot;
using System;

public class ZoneJump : Area2D {
    mouvementBonhomme bonhomme;
    public override void _Ready() {
        bonhomme = GetNode<mouvementBonhomme>("../Bonhomme");
        //disable shader on start 
         bonhomme.GetNode<ColorRect>("GlitchSprite").Visible = false;

	}

    void entreJump (object body) {
        if(body is mouvementBonhomme)
        {
            GD.Print("Jsuis dans la zone");
            bonhomme.JUMP=-400;
            //set glitch node
            bonhomme.GetNode<ColorRect>("GlitchSprite").Visible = true;
        }

    }

    void sortJump (object body) {
        bonhomme.JUMP=-350;
        //set glitch node
        bonhomme.GetNode<ColorRect>("GlitchSprite").Visible = false;
    }
}
