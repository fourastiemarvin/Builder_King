using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
      // escape key to go to the pause menu or to go back to the game
      if (Input.GetKeyDown(KeyCode.Escape)) {
        if (GameIsPaused) {
          Resume();
        } else {
          Pause();
        }
      }
    }

    public void Resume() {
      PauseMenuUI.SetActive(false);
      // unfreeze the game
      Time.timeScale = 1f;
      GameIsPaused = false;
    }

    void Pause() {
      PauseMenuUI.SetActive(true);
      // freeze the game
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu() {
      Debug.Log("Loading menu...");
      Time.timeScale = 1f;
      SceneManager.LoadScene("StartMenu");
    }

    public void LoadControls() {
      Debug.Log("Loading controls...");
      SceneManager.LoadScene("Controls");
    }
}
