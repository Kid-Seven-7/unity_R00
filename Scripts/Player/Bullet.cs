using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public	float	speed;
	public	Rigidbody2D	rb;
	public	static	int	numOfBullets = 1;
	// Use this for initialization
	void Start () 
	{

		speed = 20f;
		rb.velocity = transform.up * speed;
		if (numOfBullets >= 1)
			numOfBullets -= 1;
		Debug.Log("Bullets: " + numOfBullets);
	}
	
	void	OnTriggerEnter2D(Collider2D hitInfo)
	{
		Debug.Log("Object Name: " + hitInfo.name);
		if (!(hitInfo.name == "Player"))
			Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
