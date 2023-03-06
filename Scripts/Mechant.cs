using Godot;
using System;

public class Mechant : Area2D {
	private bool touchable=false;
	private bool reverse=false;
	mouvementBonhomme bonhomme;
	private static int numMechant = 0;
	public int idMechant;

	[Signal]
    public delegate Mechant DiminueScore(String mechant);

	public override void _Ready() {
		numMechant++;
		idMechant = numMechant;
    	bonhomme = GetNode<mouvementBonhomme>("../../Bonhomme");
	}

	void toucheMechant (object body) {
		touchable=true;

		Game game = GetNode<Game>("/root/Game");
		game.ilfautsauver=true;
	}

	void pasToucheMechant (object body) {
		touchable=false;
	}

	public override void _PhysicsProcess(float delta) {
		//get node game
		Game game = GetNode<Game>("/root/Game");
		String idDernierMechant = game.dernierMechantSauve;
		if (touchable && bonhomme.isReverse && game.ilfautsauver) {
			AnimatedSprite sprite=GetNode<AnimatedSprite>("AnimatedSprite");
            sprite.Frame=1;
			sprite.Rotation=0;
			Vector2 position=this.Position;
			position.x=0;
			position.y=-14;

			sprite.Position=position;

			EmitSignal(nameof(DiminueScore), this.idMechant.ToString());
			touchable=false;
			
		}
	}
		
}
