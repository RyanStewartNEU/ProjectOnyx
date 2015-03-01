using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MercenaryBasicProjectile : Projectile {

	private GameObject col;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		base.Update ();
		if (Physics2D.OverlapCircle (transform.position, 0.05f)) {
			col = Physics2D.OverlapCircle (transform.position, 0.05f).gameObject;
		}
		if (col != null) {
						if (col.tag == "Scenery") {
								Destroy (gameObject);
						} else if (col.tag == "Enemy") {
								col.GetComponent<EnemyController> ().takeDamage (damage, new List<Effect> (), source);
								Destroy (gameObject);
						}
				}
	}
}
