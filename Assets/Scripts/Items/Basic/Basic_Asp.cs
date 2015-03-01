using UnityEngine;
using System.Collections;

public class Basic_Asp : Items {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void applyItem(PlayerController player){
		player.asp += 5;
		player.iasp += 1;
	}
	
	public override void deApplyItem(PlayerController player){
		player.asp -= 5;
		player.iasp -= 1;
	}
}
