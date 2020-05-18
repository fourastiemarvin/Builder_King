using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
      score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      score.text = "SCORE: " + scoreValue;
    }
}
