using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}

	//Call to set the damage of a new projectile
	public void Create(int damage){
		this.damage = damage;
	}

	// Update is called once per frame
	protected void Update () {
		transform.position += transform.right * speed * Time.deltaTime; 
	}
	
}
