using Godot;
using System;

public class boutonPoto : Area2D {
    private bool touchable=false;
	private bool reverse=false;
	mouvementBonhomme bonhomme;

	public override void _Ready() {
    bonhomme = GetNode<mouvementBonhomme>("../Bonhomme");
	}

	void toucherPoto (object body) {
		if(body is mouvementBonhomme)
		{
			touchable=true;
		}
	}

	void pasToucherPotot (object body) {
		touchable=false;
	}

	public override void _PhysicsProcess(float delta) {
		if (touchable) {
			if (bonhomme.isReverse) {
				GD.Print("Oui poto tombe toussa toussa");
				Sprite sprite1=GetNode<Sprite>("Pilier13");
				Sprite sprite2=GetNode<Sprite>("Pilier14");
				sprite1.Rotation=0.16f;
				sprite2.Rotation=-0.16f;
			}
		} 
	}
}
