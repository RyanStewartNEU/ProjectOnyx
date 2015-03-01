using UnityEngine;
using System.Collections;

public class MercenaryBasicProjectile : Projectile {

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		base.Update ();
		if (Physics2D.OverlapCircle (transform.position, 0.05f).gameObject.tag=="Scenery") {
			Destroy(gameObject);
		}
		else if (Physics2D.OverlapCircle (transform.position, 0.05f).gameObject.tag=="Enemy") {
			Physics2D.OverlapCircle (transform.position, 0.05f).gameObject.GetComponent<EnemyController>().takeDamage(damage, null);
			Destroy(gameObject);
		}
	}
}
