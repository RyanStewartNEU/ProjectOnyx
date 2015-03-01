using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;
	public int lifespan=-1;
	public PlayerController source;

	// Use this for initialization
	void Start () {
	
	}

	//Call to set the damage of a new projectile
	public void Create(int damage, PlayerController source){
		this.damage = damage;
		this.source = source;
	}

	// Update is called once per frame
	protected void Update () {
		transform.position += transform.right * speed * Time.deltaTime; 
		if (lifespan > 0) {
			lifespan--;
		}
	}
	
}
