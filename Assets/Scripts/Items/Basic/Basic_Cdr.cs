using UnityEngine;
using System.Collections;

public class Basic_Cdr : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.cdr += 5;
		player.icdr += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.cdr -= 5;
		player.icdr -= 1;
	}
}
