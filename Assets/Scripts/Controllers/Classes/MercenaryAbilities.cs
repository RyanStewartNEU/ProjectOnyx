using UnityEngine;
using System.Collections;

public class MercenaryAbilities : PlayerController {

	public GameObject BasicAttackProjectile;
	public GameObject Rocket;
	public GameObject DefenseDrone;
	public GameObject SentryTurret;

	int charge=0;

	// Use this for initialization
	void Start () {
		base.Start ();
		//set base stats
		att=0;
		abp=0;
		asp=0;
		eng=0;
		cdr=0;
		hp=0;
		amr=0;
		msp=3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		base.FixedUpdate ();
		if (Input.GetAxis ("Basic") > 0 && BasicCount>=BasicCountMax && BasicAttack==false && Ability1==false &&  Ability2==false && Ult==false) {
			BasicAttack=true;
			BasicDuration=0;
			BasicCount=0;
			if(BasicAttackProjectile!=null){
				GameObject basicClone = (GameObject)Instantiate(BasicAttackProjectile.gameObject, hand.transform.position, hand.transform.rotation);
				basicClone.GetComponent<MercenaryBasicProjectile>().Create(10+att,this);
			}
		}
	}

	void Update(){
		base.Update ();
		if (Input.GetAxis ("Basic") > 0) {
			torso_anim.SetBool ("Basic", true);
			legs_anim.SetBool ("Basic", true);
			arm_anim.SetBool ("Basic", true);
		} else {
			torso_anim.SetBool ("Basic", false);
			legs_anim.SetBool ("Basic", false);
			arm_anim.SetBool ("Basic", false);
		}
	}
}
