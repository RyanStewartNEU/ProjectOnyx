using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Effectable : MonoBehaviour {
	//list of effects that this character is experiencing
	protected List<Effect> effects = new List<Effect> ();
	//list of effects this player deals to others
	public List<Effect> myEffects = new List<Effect> ();

	//add new effects to the enemy, if it already exists, add their durations instead
	protected void addEffects(List<Effect> newEffects){
		if (newEffects != null) {
			//if effects isnt empty
			foreach (Effect effect in effects) {
				foreach (Effect newEffect in newEffects) {
					if (newEffect.name == effect.name) {
						effect.duration += newEffect.duration;
					} else {
					//if it won't be updated every turn, then only apply it on effect
					if (effect.multihit == false) {
						effect.applyEffect (this);
						effect.stacks += 1;
					}
					effects.Add (newEffect);
					}
				}
			}
		}
	}
	
	//apply all effects to the enemy every update
	protected void applyEffects(){
		foreach (Effect effect in effects) {
			//if its a multihit, apply it every step
			if(effect.multihit){
				effect.applyOnTick(this);
			}
			//if its worn off, reverse its effect and remove it
			if(effect.duration<=0){
				effect.deApplyEffect(this);
				effects.Remove(effect);
			}
		}
		//draw symbols for them as well, coming later
	}
}
