using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMenu : MonoBehaviour
{
    public static bool GameInCalibration = false;
    public GameObject calibrateMenuUI;
    public GameObject pauseMenuUI;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("c")) {
        if (GameInCalibration) {
          Resume();
        } else {
          Calibrate();
        }
      }
    }

    public void Resume() {
      // recalibration of the camera according to the player
      Debug.Log(player.transform.eulerAngles.y);
      Camera.main.transform.rotation = Quaternion.Euler(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z);
      calibrateMenuUI.SetActive(false);
      pauseMenuUI.SetActive(true);
      GameInCalibration = false;
    }

    void Calibrate() {
      calibrateMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameInCalibration = true;
    }
}
