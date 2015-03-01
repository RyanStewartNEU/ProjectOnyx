using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PlayerController : Effectable {
	//collision
	GameObject col;

	//movement
	protected bool facingRight = true;
	protected Vector2 pushSpeed = new Vector2 (0, 0);

	//jump detection
	protected bool grounded = false;
	public Transform groundCheck;
	protected float groundRadius = 0.02f;
	public LayerMask whatIsGround;
	public float jumpForce = 500f;

	//post-damage invincibility
	bool invincible=false;
	int invincible_duration=0;
	int invincible_duration_max=30;

	//animators for the torso, legs and arm
	protected Animator torso_anim;
	protected Animator arm_anim;
	protected Animator legs_anim;

	//the arm object
	public GameObject torso;
	public GameObject arm;
	public GameObject shoulder;
	public GameObject legs;
	public GameObject hand;

	Vector3 mouse_pos;
	Vector3 shoulder_pos;
	public float shoulder_angle=0f;


	//Stats
	public int hp_max = 0;
	public int eng_max = 0;

	public int att=0;
	public int abp=0;
	public int asp=0;
	public int eng=0;
	public int cdr=0;
	public int hp=0;
	public int amr=0;
	public int msp=0;

	//Stat Boosts
	public int iatt=0;
	public int iabp=0;
	public int iasp=0;
	public int ieng=0;
	public int icdr=0;
	public int ihp=0;
	public int iamr=0;
	public int imsp=0;

	//xp and levels
	public int xp = 0;
	int xp_needed = 1000;
	int level = 1;
	int sk_points = 1;
	int basic_level=0;
	int skill1_level=0;
	int skill2_level=0;
	int ult_level=0;

	//Ability Cooldowns
	public int BasicCountMax = 0;
	protected int BasicCount = 0;//BasicCountMax;
	public int Ability1CountMax = 0;
	protected int Ability1Count = 0;//Ability1CountMax;
	public int Ability2CountMax = 0;
	protected int Ability2Count = 0;//Ability2CountMax;
	public int UltCountMax = 0;
	protected int UltCount = 0;//UltCountMax;
	
	//Ability Durations
	protected int BasicDurationMax=10;
	protected int BasicDuration=0;
	protected int Ability1DurationMax=0;
	protected int Ability1Duration=0;
	protected int Ability2DurationMax=0;
	protected int Ability2Duration=0;
	protected int UltDurationMax=0;
	protected int UltDuration=0;
	
	//Abilities
	protected bool BasicAttack=false;
	protected bool Ability1=false;
	protected bool Ability2=false;
	protected bool Ult=false;



	// Use this for initialization
	protected void Start () {
		torso_anim = torso.GetComponent<Animator> ();
		arm_anim = arm.GetComponent<Animator> ();
		legs_anim = legs.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected void FixedUpdate () 
	{
		//check if on the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//anim.SetBool ("Ground", grounded);
		
		//anim.SetFloat("vSpeed",rigidbody2D.velocity.y);
		
		//grab move from horizontal input axis
		float move = Input.GetAxis ("Horizontal");
		
		torso_anim.SetFloat ("hSpeed", Mathf.Abs(move));
		legs_anim.SetFloat ("hSpeed", Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (move*msp+pushSpeed.x, pushSpeed.y+rigidbody2D.velocity.y);
		//bleed off push speed over time
		pushSpeed = new Vector2 (pushSpeed.x * 0.7f, pushSpeed.y * 0.7f);
		//Arm Rotation
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 5.23f;
		shoulder_pos = Camera.main.WorldToScreenPoint(shoulder.transform.position);
		mouse_pos.x = mouse_pos.x - shoulder_pos.x;
		mouse_pos.y = mouse_pos.y - shoulder_pos.y;

		shoulder_angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		hand.transform.rotation = Quaternion.Euler (0, 0, shoulder_angle);

		if (shoulder_angle > -90 && shoulder_angle < 90) {
			if(Input.GetAxis ("Basic") > 0){
				shoulder.transform.rotation = Quaternion.Euler (0, 0, shoulder_angle);
			}
			else{
				shoulder.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}
		else{
			if(Input.GetAxis ("Basic") > 0){
				shoulder.transform.rotation = Quaternion.Euler (0, 0, 180-shoulder_angle);
			}
			else{
				shoulder.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}




		//Change Directions
		if ((shoulder_angle>-90 && shoulder_angle<90) && !facingRight) {
			Flip ();
		} 
		else if ((shoulder_angle>90 || shoulder_angle<-90) && facingRight) {
			Flip ();
		}

		//Handle Cooldowns
		if (BasicCount < BasicCountMax) {
			BasicCount++;
		}
		if (Ability1Count < Ability1CountMax) {
			Ability1Count++;
		}
		if (Ability2Count < Ability2CountMax) {
			Ability2Count++;
		}
		if (UltCount < UltCountMax) {
			UltCount++;
		}
		
		//Handle Ability Durations
		if (BasicDuration < BasicDurationMax) {
			BasicDuration++;
		}
		else{
			BasicAttack = false;
		}
		if (Ability1Duration < Ability1DurationMax) {
			Ability1Duration++;
		}
		else{
			Ability1 = false;
		}
		if (Ability2Duration < Ability2DurationMax) {
			Ability2Duration++;
		}
		else{
			Ability2 = false;
		}
		if (UltDuration < UltDurationMax) {
			UltDuration++;
		}
		else{
			Ult = false;
		}

		if (invincible_duration < invincible_duration_max) {
			invincible_duration++;
		}
		else{
			invincible=false;
		}



	}
	
	//More accurate update
	protected void Update ()
	{


		if (grounded && (Input.GetAxis("Jump")>0)) {
			//anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
	
	//flips animations over the y axis
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//for picking up items
	void ItemPickup(Items item){
		item.applyItem (this);
	}

	//for taking damage
	public void takeDamage(int damage, List<Effect> effects){
		if (amr >= damage) {
			hp -= 1;
		} else {
			hp-=(damage-amr);
		}
		addEffects (effects);
		invincible = true;
		invincible_duration = 0;
		
	}

	public void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			//if its a melee enemy, take damage and get knocked back
			if(col.gameObject.GetComponent<EnemyController>().melee){
				//take damage and get applied effects
				takeDamage (col.gameObject.GetComponent<EnemyController>().att,
				            col.gameObject.GetComponent<EnemyController>().myEffects);
				//apply knock back
				if(col.gameObject.transform.position.x>transform.position.x){
					pushSpeed=new Vector2(-5,1f);
				}
				else{
					pushSpeed=new Vector2(5,1f);
				}
			}
		}
	}
	
}
