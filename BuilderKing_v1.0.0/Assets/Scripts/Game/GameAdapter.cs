using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdapter : MonoBehaviour
{

    public static float bpm;
    public static float oldBpm;
    public static float stoneTime;
    public static float oldStoneTime;
    public static float adaptRate;
    public static bool castEnable;

    // Threshold adaptRate
    public static float hardRate = 0.5f;
    public static float easyRate = 1;

    // Start is called before the first frame update
    void Start()
    {
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
    }

    public static void Adapter() {
      stoneTime = Timer.gameTime;
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
      if (!castEnable) {
        bpm = 0;
      }
      if (bpm + stoneTime > 0) {
        if (oldStoneTime == 0) {
          adaptRate = 1.25f;
          Debug.Log("adaptRate1: "+adaptRate);
        }
        else
        {
          adaptRate = (stoneTime + bpm) / (oldStoneTime + oldBpm);
          Debug.Log("adaptRate2: "+adaptRate);
        }

        oldStoneTime = stoneTime;
        oldBpm = bpm;

        if (adaptRate > easyRate) {
          ComputeTowerHeight.spawnEasy = true;
        }
        else if (adaptRate < hardRate) {
          ComputeTowerHeight.spawnHard = true;
        }
        else {
          ComputeTowerHeight.spawnMedium = true;
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
