using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer : MonoBehaviour {

    public static float time;
    public static float startTime;
    public static float endTime;
    public static float gameTime;

    public static void StartTimer(){
        startTime = time;
    }

    public static void EndTimer(){
        endTime = time;
        gameTime = endTime - startTime;
    }

    void Update(){
        time += Time.deltaTime;
        //Debug.Log("time:"+time);
    }
}
