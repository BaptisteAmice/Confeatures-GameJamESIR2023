using Godot;
using System;

public class mouvementBonhomme : KinematicBody2D {
    [Signal] public delegate void BonhommeMortEventHandler();

    public Vector2 velocity=new Vector2();

    /*private const int speed=200;
    private const int gravity=11000;
    private const float jump=-22000;*/
    private Vector2 UP = new Vector2(0,-1);
	private int GRAVITY = 20;
	private int SPEED = 200;
	public int JUMP = -350;
    private bool isJUMP = false;

    public bool isReverse = false; 
    public bool isR = false;

	private Vector2 motion = new Vector2();

    //private const float timerDelay=0.15f;

    public void GetInput(float delta) {
        /*velocity=new Vector2();
        AnimatedSprite sprite=GetNode<AnimatedSprite>("BonhommeSpriteMarche");
        Timer timer=GetNode<Timer>("TimerJump");

        if (Input.IsActionPressed("move_right") ||Input.IsActionPressed("move_left")) {
            velocity.x+=speed*((Input.IsActionPressed("move_right") ? 1 : 0) - ((Input.IsActionPressed("move_left") ? 1 : 0)));
        }

        if ( IsOnFloor() && Input.IsActionPressed("move_up")) {
            timer.Start(timerDelay);
        }
        if (timer.TimeLeft>0) {
             velocity.y+=delta*jump;
        } else {
                velocity.y+=delta*gravity;
        }*/
        
    }

    public override void _PhysicsProcess(float delta) {
        if(Input.IsActionPressed("reversed") && !isR) {
            isR=true;
            isReverse=!isReverse;
        }

        if (Input.IsActionPressed("reversed") != true) {
            isR=false;
        }

        if (isReverse) {
            GRAVITY = 10;
            SPEED = 100;
            GetNode<ColorRect>("GlitchSprite").Visible = false;
            GetNode<Node2D>("Glitch").Visible = true;
            if(Input.IsActionPressed("move_left")) {
                AnimatedSprite marche = GetNode<AnimatedSprite>("BonhommeSpriteMarche");
                marche.FlipH = true;
                Vector2 position=marche.Position;
                position.x=-6;
                marche.Position=position;
                GetNode<Sprite>("BonhommeSpritePause").FlipH = true;
                GetNode<AnimatedSprite>("BonhommeSpriteAttack").FlipH = true;
		    } else if(Input.IsActionPressed("move_right")){
			    AnimatedSprite marche = GetNode<AnimatedSprite>("BonhommeSpriteMarche");
                marche.FlipH = false;
                Vector2 position=marche.Position;
                position.x=0;
                marche.Position=position;
                GetNode<Sprite>("BonhommeSpritePause").FlipH = false;
                GetNode<AnimatedSprite>("BonhommeSpriteAttack").FlipH = false;
            }
           
        } else {
            GRAVITY = 20;
            SPEED = 200;
            GetNode<Node2D>("Glitch").Visible = false;
            if(Input.IsActionPressed("move_right")) {
                AnimatedSprite marche = GetNode<AnimatedSprite>("BonhommeSpriteMarche");
                marche.FlipH = true;
                Vector2 position=marche.Position;
                position.x=-6;
                marche.Position=position;
                GetNode<Sprite>("BonhommeSpritePause").FlipH = true;
                GetNode<AnimatedSprite>("BonhommeSpriteAttack").FlipH = true;
		    } else if(Input.IsActionPressed("move_left")){
			    AnimatedSprite marche = GetNode<AnimatedSprite>("BonhommeSpriteMarche");
                marche.FlipH = false;
                Vector2 position=marche.Position;
                position.x=0;
                marche.Position=position;
                GetNode<Sprite>("BonhommeSpritePause").FlipH = false;
                GetNode<AnimatedSprite>("BonhommeSpriteAttack").FlipH = false;
            }
        }

        motion.y += GRAVITY;
		if(Input.IsActionPressed("move_right")) {
			motion.x = SPEED;
		} else if(Input.IsActionPressed("move_left")){
			motion.x = -SPEED;
		} else {
			motion.x = 0;
		}
		if(IsOnFloor() && isJUMP == false) {
			if(Input.IsActionPressed("move_up")) {
                motion.y = JUMP;
                isJUMP = true;
            }
				
		}
        if (Input.IsActionPressed("move_up") != true)
            isJUMP = false;
            
		motion = MoveAndSlide(motion, UP);
    }

}

public partial class CustomSignal : KinematicBody2D {
    [Signal] public delegate void BonhommeMortEventHandler();
}