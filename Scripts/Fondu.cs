using Godot;
using System;

public class Fondu : ColorRect
{
    Color color = new Color(0, 0, 0, 0);
    bool isFading = false;

    //on ready
    public override void _Ready()
    {
        //transparent
        color.a = 0;
        Modulate = color;

    }

    public void _on_AreaFondu_body_entered(Node body)
    {
        if (body is mouvementBonhomme)
        {
            isFading = true;
        }
    }
    
    public override void _Process(float delta)
    {
        if (isFading)
        {
            color.a += 0.01f;
            Modulate = color;
        }
        if(color.a >= 1)
        {
            GetTree().ChangeScene("res://Scenes/Menu.tscn");
        }
    }
}
