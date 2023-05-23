using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    public static bool Paused;

	private void Start()
	{
        ResumeButton();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

	private void Pause()
    {
        Paused = true;
        Time.timeScale = 0f;
		_pauseMenu.SetActive(true);
	}

    public void ResumeButton()
    {
        Paused = false;
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
