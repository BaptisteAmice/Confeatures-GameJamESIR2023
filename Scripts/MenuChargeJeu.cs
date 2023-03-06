using Godot;
using System;

public class MenuChargeJeu : Control
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnJouerPressed() {
        GetTree().ChangeScene("res://Scenes/Game_over.tscn");
    }
    public void OnQuitterPressed() {
        GetTree().Quit();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
