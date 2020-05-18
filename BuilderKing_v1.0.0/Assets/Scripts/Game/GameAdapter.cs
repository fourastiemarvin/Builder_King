using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdapter : MonoBehaviour
{

    private HeartRateRequester _heartRateRequester;

    public static float bpm;
    public static float oldBpm;
    public static float stoneTime;
    public static float oldStoneTime;
    public static float adaptRate;
    public static bool castEnable;

    // Threshold adaptRate
    public static float hardRate = 0.75f;
    public static float easyRate = 1.25f;

    public static bool flagCall = false;

    // Start is called before the first frame update
    void Start()
    {
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
    }

    public static void Adapter() {
      flagCall = true;
      stoneTime = Timer.gameTime;
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
      if (!castEnable) {
        bpm = 0;
      }
      if (oldStoneTime == 0) {
        // Second spawn
        adaptRate = 1.3f;
        Debug.Log("adapt 2nd:"+adaptRate);
        Debug.Log("t:"+stoneTime);
        Debug.Log("old t:"+oldStoneTime);
      }
      else {
        if (stoneTime < oldStoneTime + oldStoneTime * 0.2) {
          if (bpm > oldBpm + 20) {
            // Easy spawn
            adaptRate = 1.3f;
          } else if (bpm > oldBpm + 10) {
            // Medium spawn
            adaptRate = 1f;
          } else {
            // Hard spawn
            adaptRate = 0.7f;
          }
          Debug.Log("adapt:"+adaptRate);
          Debug.Log("t:"+stoneTime);
          Debug.Log("old t:"+oldStoneTime);
        }
        else if (stoneTime < oldStoneTime + oldStoneTime * 0.5) {
          if (bpm > oldBpm + 10) {
            // Easy spawn
            adaptRate = 1.3f;
          } else if (bpm < oldBpm - 10) {
            // Hard spawn
            adaptRate = 0.7f;
          } else {
            // Medium spawn
            adaptRate = 1f;
          }
          Debug.Log("adapt:"+adaptRate);
          Debug.Log("t:"+stoneTime);
          Debug.Log("old t:"+oldStoneTime);
        }
        else {
          if (bpm < oldBpm - 20) {
            // Hard spawn
            adaptRate = 0.7f;
          } else if (bpm < oldBpm - 10) {
            // Medium spawn
            adaptRate = 1f;
          } else {
            // Easy spawn
            adaptRate = 1.3f;
          }
          Debug.Log("adapt:"+adaptRate);
          Debug.Log("t:"+stoneTime);
          Debug.Log("old t:"+oldStoneTime);
        }
      }

      if (adaptRate > easyRate) {
        ComputeTowerHeight.spawnEasy = true;
      }
      else if (adaptRate < hardRate) {
        ComputeTowerHeight.spawnHard = true;
      }
      else {
        ComputeTowerHeight.spawnMedium = true;
      }

      oldStoneTime = stoneTime;
      oldBpm = bpm;
    }

    // Update is called once per frame
    void Update()
    {
      if (flagCall) {
        _heartRateRequester = new HeartRateRequester();
        _heartRateRequester.Start();
        flagCall = false;
      }
    }


    private void OnDestroy()
    {
        _heartRateRequester.Stop();
    }
}
