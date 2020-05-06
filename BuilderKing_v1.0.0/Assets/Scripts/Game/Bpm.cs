using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bpm : MonoBehaviour
{
    public static string bpmValue;
    Text bpm;

    // Start is called before the first frame update
    void Start()
    {
      bpm = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      if (bpmValue != "0") {
        bpm.text = "bpm: " + bpmValue;
      }
    }
}
