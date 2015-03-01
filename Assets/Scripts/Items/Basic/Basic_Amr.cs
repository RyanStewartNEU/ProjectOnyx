using UnityEngine;
using System.Collections;

public class Basic_Amr : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.amr += 1;
		player.iamr += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.amr -= 1;
		player.iamr -= 1;
	}
}
