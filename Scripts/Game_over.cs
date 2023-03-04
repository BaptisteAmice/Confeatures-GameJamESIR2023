using Godot;
using System;

public class Game_over : Control {
    public void OnButtonPressed() {
        GetTree().ChangeScene("res://Scenes/Game.tscn");
    }
}
