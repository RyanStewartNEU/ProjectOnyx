using UnityEngine;
using System.Collections;

public class Basic_Abp : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.abp += 5;
		player.iabp += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.abp -= 5;
		player.iabp -= 1;
	}
}
