using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    private GameObject _pauseMenu;

	/// <summary>
	/// Track whether the application is paused or not
	/// </summary>
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

    /// <summary>
    /// Pauses the simulation.
    /// </summary>
	private void Pause()
    {
        Paused = true;
        Time.timeScale = 0f;
		_pauseMenu.SetActive(true);
        Cursor.visible = true;
	}

    /// <summary>
    /// Resumes if paused.
    /// </summary>
    public void ResumeButton()
    {
        Paused = false;
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    /// <summary>
    /// Quit the simulation.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
