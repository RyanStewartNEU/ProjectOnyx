using UnityEngine;
using System.Collections;

public class Slow_Effect : Effect {
	//One time hit slowing effect

	public Slow_Effect(int duration, int amount, bool multihit, int total_stacks){
		this.duration = duration;
		this.amount = amount;
		this.multihit = multihit;
		this.total_stacks = total_stacks;
	}

	// Use this for initialization
	void Start () {
		name = "Slow";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void applyEffect(Effectable player){
		if (player.gameObject.tag == "Player") {
			player.gameObject.GetComponent<PlayerController>().msp-=amount;
		}
		else if(player.gameObject.tag=="Enemy"){
			player.gameObject.GetComponent<EnemyController>().msp-=amount;
		}
	}

	void applyOnTick(Effectable player){

	}

	void deApplyEffect(Effectable player){
		if (player.gameObject.tag == "Player") {
			player.gameObject.GetComponent<PlayerController>().msp+=10;
		}
		else if(player.gameObject.tag=="Enemy"){
			player.gameObject.GetComponent<EnemyController>().msp+=10;
		}
	}
}
