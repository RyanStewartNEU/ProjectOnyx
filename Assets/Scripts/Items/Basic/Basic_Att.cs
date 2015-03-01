using UnityEngine;
using System.Collections;

public class Basic_Att : Items {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void applyItem(PlayerController player){
		player.att += 5;
		player.iatt += 1;
	}

	public override void deApplyItem(PlayerController player){
		player.att -= 5;
		player.iatt -= 1;
	}
}
