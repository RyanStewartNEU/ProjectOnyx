using UnityEngine;
using System.Collections;

public class Beetle : EnemyController {
	
	public Transform groundCheck;
	public Transform wallCheck;
	// Use this for initialization
	void Start () {
		hp = 50+10*level;
		att = 5+5*level;
		msp = 0.03f;
		speed = msp;
		melee = true;
		effects.Add(new Slow_Effect(120,1,false,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Die ();
		}

	}

	void FixedUpdate() {
		transform.position += transform.right * speed;
		//flip if touching wall
		if (Physics2D.OverlapCircle (wallCheck.position, 0.05f) != null) {
			if (Physics2D.OverlapCircle (wallCheck.position, 0.05f).gameObject.tag == "Scenery") {
				Flip ();
			}
		}
		//flip if about to fall off edge
		if (Physics2D.OverlapCircle (groundCheck.position, 0.05f) == null) {
			Flip ();
		}
	}

	void Flip(){
		speed *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Die(){
		lastDamage.xp += 100;
		Destroy (gameObject);
	}
}
