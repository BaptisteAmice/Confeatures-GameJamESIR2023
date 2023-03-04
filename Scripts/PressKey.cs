using Godot;
using System;

public class PressKey : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //hide the scene
        CacheScene();
        
    }


    public void CacheScene()
    {
        //hide the scene
        this.Visible = false;
    }

    public void AfficheScene()
    {
        //show the scene
        this.Visible = true;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
