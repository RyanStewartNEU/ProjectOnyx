using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Effectable : MonoBehaviour {

	protected List<Effect> effects = new List<Effect> ();

	//add new effects to the enemy, if it already exists, add their durations instead
	protected void addEffects(List<Effect> newEffects){
		foreach (Effect effect in effects) {
			foreach (Effect newEffect in newEffects){
				if(newEffect.name==effect.name){
					effect.duration+=newEffect.duration;
				}
				else{
					//if it won't be updated every turn, then only apply it on effect
					if(effect.multihit==false){
						effect.apply();
						effect.stacks+=1;
					}
					effects.Add(newEffect);
				}
			}
		}
	}
	
	//apply all effects to the enemy every update
	protected void applyEffects(){
		foreach (Effect effect in effects) {
			//if its a multihit, apply it every step
			if(effect.multihit){
				effect.apply();
			}
			//if its worn off, reverse its effect and remove it
			if(effect.duration<=0){
				effect.deApply();
				effects.Remove(effect);
			}
		}
		//draw symbols for them as well, coming later
	}
}
