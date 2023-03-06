using Godot;
using System;
using System.Collections;

public class Game : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    //get drapeau nodes
    private Godot.Collections.Array drapeauNodes;
    private Drapeau checkpoint;
    private mouvementBonhomme bonhomme;

    public int piecesNumber;

    private bool potouche=false;

    private int score=0;
    private int scorePerEnemy = 50;
    public String dernierMechantSauve = "-1";
    public bool ilfautsauver = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //get Bonhomme node
        bonhomme = GetNode<mouvementBonhomme>("Bonhomme");

        Drapeaux_setup();

        
        Node pieces = GetNode("Pieces");
        Godot.Collections.Array piecesNodes = pieces.GetChildren();
        //count piece note in array
        foreach (Node child in piecesNodes)
        {
 
            piecesNumber++;
            
        }
        
        //set piece number in RichTextLabel
        SetPiecesInPlayer(piecesNumber);

        
        GD.Print(piecesNumber);

        //connects signal to method for piece
        //GetNode("Piece").Connect("PieceTouched", this, "PieceCollected");

        //get piecesVisuals node
        Node2D piecesVisuals = GetNode<mouvementBonhomme>("Bonhomme").GetNode<Node2D>("Pieces");

        //hide it
        piecesVisuals.Visible = false;

        Node mechants = GetNode("Mechants");
        Godot.Collections.Array mechantsNodes = mechants.GetChildren();
        //count piece note in array
        foreach (Node child in mechantsNodes)
        {
            //connects signal to method for piece
            child.Connect("DiminueScore", this, "DiminueScore");
            score = score + scorePerEnemy;
        }


        //get piecesVisuals node
        Node2D mechantsVisuels = GetNode<mouvementBonhomme>("Bonhomme").GetNode<Node2D>("Score");

        //show it
        mechantsVisuels.Visible = false;

        //set score number in RichTextLabel
        RichTextLabel mechantsLabel = mechantsVisuels.GetNode<RichTextLabel>("Text");
        mechantsLabel.Text = score.ToString() + "PTS";
        
    }

    public void PieceCollected()
    {
        //decrease piece number
        piecesNumber--;
        //set piece number in RichTextLabel
        SetPiecesInPlayer(piecesNumber);

        GD.Print("lol"+piecesNumber);
    }

        public void _on_DeadZone_body_entered(object body) {
        if (body is mouvementBonhomme) {
            GD.Print("DeadZone touché");
            //teleport Bonhomme to checkpoint position
            teleportToCheckpoint();
        }
    }

    public void Drapeaux_setup() {
        //get drapeau nodes
        drapeauNodes = GetNode("Drapeaux").GetChildren();
        //sho all drapeau names
        foreach (Node drapeau in drapeauNodes)
        {
            GD.Print(drapeau.Name);
            //connects signal to method for drapeau
            drapeau.Connect("BreakDrapeau", this, "BriseDrapeau");
        }

        //get first drapeau
        checkpoint = (Drapeau)drapeauNodes[0];
        //cget its animated sprite and set it to 0
        checkpoint.GetNode<AnimatedSprite>("AnimatedSprite").Frame = 0;

    }

    public void teleportToCheckpoint() {
        //get checkpoint position
        Vector2 checkpointPosition = checkpoint.Position;
        //y-10 to avoid teleporting in the ground
        checkpointPosition.y -= 10;
        //teleport Bonhomme to checkpoint position
        bonhomme.Position = checkpointPosition;
        AudioStreamPlayer2D mortAudio= GetNode<Node>("Audios").GetNode<AudioStreamPlayer2D>("Mort");
        //play it one time
        mortAudio.Play();
    }

    public void BriseDrapeau(Drapeau drapeau) {
        //checkpoint becomes value next to drapeau in drapeauNodes
        int index = drapeauNodes.IndexOf(drapeau);
        if (index < drapeauNodes.Count - 1)
        {
            checkpoint = (Drapeau)drapeauNodes[index + 1];
        }
        else
        {
            checkpoint = (Drapeau)drapeauNodes[0];
        }
        //hide the drapeau
        drapeau.Hide();
        //get audio node
        AudioStreamPlayer2D drapeauAudio = GetNode<Node>("Audios").GetNode<AudioStreamPlayer2D>("Drapeau");
        //play it one time
        drapeauAudio.Play();
    }

    public void SetPiecesInPlayer(int number)
    {
        //get piecesVisuals node
        Node2D piecesVisuals = GetNode<mouvementBonhomme>("Bonhomme").GetNode<Node2D>("Pieces");

        //show it
        piecesVisuals.Visible = true;
        //hide it after 2 seconds
        GetTree().CreateTimer(2).Connect("timeout", piecesVisuals, "HideIt");

        //set piece number in RichTextLabel
        RichTextLabel piecesLabel = piecesVisuals.GetNode<RichTextLabel>("ComptePieces");
        piecesLabel.Text = number.ToString();
        
    }

    void toucherPoto (object body) {
        if(body is mouvementBonhomme)
        {
            potouche=true;
            GD.Print("oui");

        }
    }

    void pasToucherPoto (object body) {
        potouche=false;
    }

    public override void _PhysicsProcess(float delta) {
        if (potouche==true && bonhomme.isReverse) {
            StaticBody2D sprite1=GetNode<StaticBody2D>("Pilier13");
            StaticBody2D sprite2=GetNode<StaticBody2D>("Pilier14");
            sprite1.Rotation=0.10472f;
            sprite2.Rotation=-0.10472f;
        }

        if(Input.IsActionPressed("attack"))
        {
            AudioStreamPlayer2D hacheAudio= GetNode<Node>("Audios").GetNode<AudioStreamPlayer2D>("Hache");
            //play it one time
            hacheAudio.Play();
        }
    }

    public void DiminueScore(String mechant)
    {
        if(mechant!=dernierMechantSauve)
        {
            GD.Print("mechant"+mechant);
            GD.Print("dernier"+dernierMechantSauve);
            score=score-scorePerEnemy;
            GD.Print("score"+score);
            //get piecesVisuals node
            Node2D mechantsVisuels = GetNode<mouvementBonhomme>("Bonhomme").GetNode<Node2D>("Score");
            //show it
            mechantsVisuels.Visible = true;
            //hide it after 2 seconds
            GetTree().CreateTimer(2).Connect("timeout", mechantsVisuels, "HideIt");
            //set score number in RichTextLabel
            RichTextLabel mechantsLabel = mechantsVisuels.GetNode<RichTextLabel>("Text");
            mechantsLabel.Text = score.ToString() + "PTS";

            dernierMechantSauve=mechant;
            ilfautsauver=false;

        }
    
    }

    

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
