using Godot;
using System;

public class pauseBonhomme : Sprite {
    [Export] public int mort=0;

    /*public void Death() {
        Vector2 position=this.Position;
        this.Modulate=new Color(0.95f, 0.25f, 0.25f);
        this.Rotation=-Mathf.Pi/2;
        position.y=14;
        this.Position=position;
        mort=1;
    }

    public void Revivre() {
        Vector2 position=this.Position;
        this.Modulate=new Color(1, 1, 1);
        this.Rotation=0;
        position.y=0;
        this.Position=position;
    }*/

    public override void _PhysicsProcess(float delta) {
        if (Input.IsActionPressed("move_right") || Input.IsActionPressed("move_left")) {
            this.Visible=false;
        } else {
            this.Visible=true;
        }

         if (Input.IsActionPressed("move_right")) {
            this.FlipH=true;
        }

        if (Input.IsActionPressed("move_left")) {
            this.FlipH=false;
        }

        if (Input.IsActionPressed("attack")) {
            this.Visible=false;
        }

        /*if (Input.IsActionPressed("suicide")) {Death();} 
        else if (mort==1) {
            Revivre();
        }*/
    }
}
