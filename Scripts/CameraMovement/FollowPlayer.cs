﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	// Use this for initialization
	public	GameObject	Player;
	private	Vector3	offset;

	void Start () 
	{
		offset = transform.position - Player.transform.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = Player.transform.position + offset;
	}
}
