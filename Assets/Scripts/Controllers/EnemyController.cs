using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : Effectable {

	public int att=0;
	public int asp=0;
	public int hp=0;
	public int hp_max = 0;
	public int amr=0;
	public float msp=0;
	public bool melee;
	public int level;
	public float speed;
	//who to give credit for the kill to
	public PlayerController lastDamage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {

	}

	public void takeDamage(int damage, List<Effect> effects, PlayerController source){
		if (amr >= damage) {
			hp -= 1;
		} else {
			hp-=(damage-amr);
		}
		addEffects (effects);
		lastDamage = source;

	}

	protected virtual void Die(){

	}


}
