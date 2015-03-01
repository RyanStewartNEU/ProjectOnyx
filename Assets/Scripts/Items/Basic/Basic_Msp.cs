using UnityEngine;
using System.Collections;

public class Basic_Msp : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.msp += 5;
		player.imsp += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.msp -= 5;
		player.imsp -= 1;
	}
}
