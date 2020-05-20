using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardSelector : MonoBehaviour
{
    public static string keyboard;
    // Start is called before the first frame update
    public void SwissUs() {
      keyboard = "SwissUs";
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void French() {
      keyboard = "French";
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
