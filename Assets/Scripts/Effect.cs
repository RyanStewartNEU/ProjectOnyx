using UnityEngine;
using System.Collections;

public class Effect : MonoBehaviour {

	public string name;
	public int duration;
	public int amount;
	public bool multihit;
	public int stacks;
	public int total_stacks;


	public virtual void applyEffect(Effectable player){

	}

	public virtual void applyOnTick(Effectable player){

	}

	public virtual void deApplyEffect(Effectable player) {

	}
}
