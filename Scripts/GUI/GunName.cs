using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunName : MonoBehaviour 
{
	public	Text	gunName;
	public	Text	bulletsLeft;
	// Update is called once per frame
	void Update () 
	{
		gunName.text = "Gun: " + PlayerMouseDirection.nameOfGun;
		bulletsLeft.text = "Bullets: " + Bullet.numOfBullets.ToString();
	}
}
