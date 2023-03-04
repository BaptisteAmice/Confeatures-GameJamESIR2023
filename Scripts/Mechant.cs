using Godot;
using System;

public class Mechant : Area2D {
	private bool touchable=false;

	void toucheMechant (object body) {
		touchable=true;
	}

	void pasToucheMechant (object body) {
		touchable=false;
	}

	public override void _PhysicsProcess(float delta) {
		if (Input.IsActionJustPressed("interect") && touchable) {
			AnimatedSprite sprite=GetNode<AnimatedSprite>("AnimatedSprite");
            sprite.Frame=1;
			sprite.Rotation=0;
			Vector2 position=this.Position;
			position.x=0;
			position.y=-14;

			sprite.Position=position;
		}
	}
		
}
