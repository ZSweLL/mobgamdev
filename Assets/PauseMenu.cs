using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu() {
        SceneManager.LoadScene(0);

    }

    public void Quit() {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
