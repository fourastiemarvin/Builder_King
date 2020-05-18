using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void playGame() {
      Time.timeScale = 1f;
      Scoring.scoreValue = 0;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
      Debug.Log("QUIT");
      Application.Quit();
    }
}
