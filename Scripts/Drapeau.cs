using Godot;
using System;

public class Drapeau : Area2D {
	static public int numDrapeau = 0;
	public int idDrapeau;
	public bool breakable=false;

    PressKey pressKey;

	[Signal]
    public delegate Drapeau BreakDrapeau(Drapeau drapeau);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		numDrapeau++;
		idDrapeau = numDrapeau;
        pressKey = GetNode<PressKey>("PressKey");
	}

	public void _on_Drapeau_body_entered(object body)
	{
		if (body is mouvementBonhomme)
		{
            pressKey.AfficheScene();
			
			GD.Print("Drapeau touché");
			breakable = true;
		}
	}

	public void _on_Drapeau_body_exited(object body)
	{
		if (body is mouvementBonhomme)
		{
			pressKey.CacheScene();
			GD.Print("Drapeau quitté");
		}
		breakable = false;
	}

	public void TryBreak()
	{
		GD.Print("key pressed");
		if (breakable)
		{
			GD.Print("drapeau cassable");
			//emit signal to Game.cs
			EmitSignal(nameof(BreakDrapeau), this);
			breakable = false;
		}
	}

	public void GetInput(float delta)
	{
		if (Input.IsActionJustPressed("attack"))
		{
			TryBreak();
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		GetInput(delta);
	}
}
