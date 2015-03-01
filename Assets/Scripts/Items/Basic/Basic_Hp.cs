using UnityEngine;
using System.Collections;

public class Basic_Hp : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.hp_max += 10;
		player.ihp += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.hp_max -= 10;
		player.ihp -= 1;
	}
}
