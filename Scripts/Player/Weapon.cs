using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
	public	Transform	firePoint;
	public	GameObject	shotgunBullet;
	public	GameObject	rocketLauncherBullet;
	public	GameObject	machineGunBullet;
	public	GameObject	saberSlice;
	public	Animator	saberAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (PlayerMouseDirection.hasGun)
			{
				if (Bullet.numOfBullets >= 1)
					Shoot();
				else if (PlayerMouseDirection.currentGunPrefab == 4)
					Shoot();				
			}
			
		}
		else if (PlayerMouseDirection.currentGunPrefab == 4 && PlayerMouseDirection.hasGun)
			saberAnim.SetInteger("Weapon", 4);
	}

	void	Shoot()
	{
		if (PlayerMouseDirection.currentGunPrefab == 1)
		{
			FindObjectOfType<AudioManager>().Play("ShotGunSound");
			Instantiate(shotgunBullet, firePoint.position, firePoint.rotation);
		}
		else if (PlayerMouseDirection.currentGunPrefab == 2)
		{
			FindObjectOfType<AudioManager>().Play("MachineGunSound");
			Instantiate(machineGunBullet, firePoint.position, firePoint.rotation);
		}
		else if (PlayerMouseDirection.currentGunPrefab == 3)
		{
			FindObjectOfType<AudioManager>().Play("RocketGunSound");
			Instantiate(rocketLauncherBullet, firePoint.position, firePoint.rotation);
		}
		else if (PlayerMouseDirection.currentGunPrefab == 4)
		{
			Debug.Log("Saber Slice!");
			saberAnim.SetInteger("Weapon", 5);
		}
	}
}
