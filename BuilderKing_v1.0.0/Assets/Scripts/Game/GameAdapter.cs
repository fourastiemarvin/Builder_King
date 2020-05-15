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

    public static bool flagHard = true;
    public static bool flagMedium = true;

    // Start is called before the first frame update
    void Start()
    {
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
      Debug.Log("castE:"+ castEnable);
      Debug.Log("bpm: "+ Bpm.bpmValue);
      Debug.Log("t: "+ Timer.gameTime);
    }

    public static void Adapter() {
      stoneTime = Timer.gameTime;
      castEnable = float.TryParse(Bpm.bpmValue, out bpm);
      if (!castEnable) {
        bpm = 0;
      }
      if (bpm + stoneTime > 0) {
        if (oldStoneTime == 0) {
          if (DragObjectUpdate.rock.name == "MediumRockMovable(Clone)") {
            adaptRate = 0.75f;
            flagMedium = false;
          }
          if (DragObjectUpdate.rock.name == "HardRockMovable(Clone)") {
            adaptRate = 0.25f;
            flagHard = false;
          }
          if (DragObjectUpdate.rock.name == "EasyRockMovable(Clone)") {
            adaptRate = 1.25f;
          }
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
          if (DragObjectUpdate.rock.name == "EasyRockMovable(Clone)") {
            ComputeTowerHeight.removeMedium = true;
            ComputeTowerHeight.removeHard = true;
          }
        }
        else if (adaptRate < hardRate) {
          ComputeTowerHeight.spawnHard = true;
          if (DragObjectUpdate.rock.name == "HardRockMovable(Clone)") {
            if (flagHard) {
              ComputeTowerHeight.removeEasy = true;
            }
            if (!flagHard) {
              adaptRate = 1.25f;
            }
            ComputeTowerHeight.removeMedium = true;
          }
        }
        else {
          ComputeTowerHeight.spawnMedium = true;
          if (DragObjectUpdate.rock.name == "MediumRockMovable(Clone)") {
            if (flagMedium) {
              ComputeTowerHeight.removeEasy = true;
            }
            if (!flagMedium) {
              adaptRate = 1.25f;
            }
            ComputeTowerHeight.removeHard = true;
          }
        }
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
