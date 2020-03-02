using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    private bool gamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (gamePaused)
                Resume();
            else
                Pause();
    }
    private void Pause()
    {
        Debug.Log("pause");
  
        gamePaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    }

    public void Resume()
    {
        Debug.Log("resume");

        gamePaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
    }

    public void HomeButtonPress()
    {
        Debug.Log("Home");
        SceneManager.LoadScene(0);
    }
    public void ExitButtonPress()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
