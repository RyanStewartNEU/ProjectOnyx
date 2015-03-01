using UnityEngine;
using System.Collections;

public class Basic_Eng : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.eng_max += 10;
		player.ieng += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.eng_max -= 10;
		player.ieng -= 1;
	}
}
