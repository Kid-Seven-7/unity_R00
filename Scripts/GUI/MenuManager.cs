using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public	static	int	enemiesLeft = 4;
	public	static bool	isPlayerAlive = true;
	public	GameObject	pauseMenuUI;
	public	GameObject	winMenu;

	// Update is called once per frame
	void Update () 
	{
		if (!isPlayerAlive)
		{
			pauseMenuUI.SetActive(true);
		}
		else if (enemiesLeft < 1)
		{
			winMenu.SetActive(true);
		}
		else if (PlayerMouseDirection.gameWon)
		{
			winMenu.SetActive(true);
		}
	}

	public void	RestartGame()
	{
		isPlayerAlive = true;
		PlayerMouseDirection.gameWon = false;
		pauseMenuUI.SetActive(false);
		winMenu.SetActive(false);
		SceneManager.LoadScene("Game");
	}

	public	void	ExitGame()
	{
		Application.Quit();
	}
}
