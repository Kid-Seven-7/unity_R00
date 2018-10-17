using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseDirection : MonoBehaviour 
{
	public	static	bool	gameWon = false;
	public	Animator	animator;
	public	Animator	gunAnimator;
	public	bool	isRunning;
	public	float	playerSpeed;
	public	GameObject	pickUp;
	public	Vector3	moveHorizontal;
	public	Vector3	moveVertical;
	private	bool	isGun;
	public static	bool	hasGun;
	public	static	int	currentGunPrefab;
	public	static	string	nameOfGun;

	// Use this for initialization
	void Start () 
	{
		currentGunPrefab = 0;
		isRunning = false;
		playerSpeed = 10f;
		moveHorizontal = new Vector3(playerSpeed, 0f, 0f);
		moveVertical = new Vector3(0f, playerSpeed, 0f);
		isGun = false;
		hasGun = false;
		FindObjectOfType<AudioManager>().Play("GamePlaySound");
	}
	
	// Update is called once per frame
	void Update () 
	{
		faceMouse();
		movePlayer();
	}

	//------------------------------Movement Keys for the Player------------------//
	void	movePlayer()
	{
		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			isRunning = true;
			transform.position += moveVertical * Time.deltaTime;
		}
		else if (Input.GetKey("a") || Input.GetKey("left"))
		{
			isRunning = true;
			transform.position -= moveHorizontal * Time.deltaTime;
		}
		else if (Input.GetKey("s") || Input.GetKey("down"))
		{
			isRunning = true;
			transform.position -=moveVertical * Time.deltaTime;
		}
		else if (Input.GetKey("d") || Input.GetKey("right"))
		{
			isRunning = true;
			transform.position += moveHorizontal * Time.deltaTime;
		}
		else if (Input.GetKeyDown("e") && isGun)
		{
			if (pickUp.activeSelf == true && !hasGun)
			{
				Debug.Log("Current Weapon: " + pickUp.name);
				changeGunAnimation(pickUp.name);
				pickUp.gameObject.SetActive(false);
				hasGun = true;
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{
			if (pickUp.activeSelf != true)
			{
				changeGunAnimation();
				pickUp.gameObject.SetActive(true);
				isGun = false;
				hasGun = false;
				ThrowGun();
			}
		}
		else
			isRunning = false;
		animator.SetBool("isRunning", isRunning);
	}

	//------------------------------Getting mouse direction for the player--------//
	void	faceMouse()
	{
		Vector2 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		
		//Getting coords
		float x_direction =	transform.position.x - mousePosition.x;
		float y_direction = transform.position.y - mousePosition.y;

		//Mouse direction
		transform.up = new Vector2(x_direction, y_direction);
	}

	//------------------------------Gets triggered if player == gun---------------//
	void	OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "GUN")
		{
			if (!hasGun)
			{
				isGun = true;
				pickUp = other.gameObject;
			}
		}
		else if (other.gameObject.tag == "Saber")
		{
			if (!hasGun)
			{
				isGun = true;
				pickUp = other.gameObject;
			}	
		}
	}

	//------------------------------Changing the gun a player is holding----------//
	void	changeGunAnimation(string gunName = "")
	{
		nameOfGun = gunName;
		if (gunName == "Shotgun")
		{
			currentGunPrefab = 1;
			Bullet.numOfBullets = 23;
			gunAnimator.SetInteger("Weapon", 1);
		}
		else if (gunName == "MachineGun")
		{
			currentGunPrefab = 2;
			Bullet.numOfBullets = 23;
			gunAnimator.SetInteger("Weapon", 2);
		}
		else if (gunName == "RocketLauncher")
		{
			currentGunPrefab = 3;
			Bullet.numOfBullets = 23;
			gunAnimator.SetInteger("Weapon", 3);
		}
		else if (gunName == "Saber")
		{
			currentGunPrefab = 4;
			Bullet.numOfBullets = 1;
			gunAnimator.SetInteger("Weapon", 4);
		}
		else if (gunName == "")
		{
			Bullet.numOfBullets = 0;
			gunAnimator.SetInteger("Weapon", 0);
		}
	}

	void	OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "carBlack")
			gameWon = true;
		if (other.gameObject.tag == "GUN")
		{
			if(!hasGun)
			{
				isGun = true;
				pickUp = other.gameObject;
			}
		}
		else if (other.gameObject.tag == "Saber")
		{
			if(!hasGun)
			{
				isGun = true;
				pickUp = other.gameObject;
			}
		}
	}
	void	OnTriggerExit2D(Collider2D other)
	{
		if (!hasGun)
			isGun = false;
	}

	void	ThrowGun()
	{
		//Mouse direction
		pickUp.transform.position = transform.position + new Vector3(1f, 1f, -1f);	
	}
}
