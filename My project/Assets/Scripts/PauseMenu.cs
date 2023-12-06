using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    private bool pausedGame = false;

     public void Start() {
       Time.timeScale = 1f;
    }

    public void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pausedGame) {
                Resume();
            }
            else {
                    Pause();
            }
        }
    }


    public void Pause() {
        pausedGame = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume() {
        pausedGame = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart() {
        pausedGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        Debug.Log("Closing game");
        Application.Quit();
    }

}
