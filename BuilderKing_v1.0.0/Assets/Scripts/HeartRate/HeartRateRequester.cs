using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;
using System;

public class HeartRateRequester : RunAbleThread{

    public static string bpm;

    protected override void Run(){
        ForceDotNet.Force(); // this line is needed to prevent unity freeze after one use, not sure why yet
        using (RequestSocket client = new RequestSocket()){
            TimeSpan timeout = new TimeSpan(0,0,2);

            // client.Connect("tcp://localhost:5555");
            client.Connect("tcp://localhost:4444");

            string message = null;
            // Debug.Log("Sending Hello");
            bool send = client.TrySendFrame("Hello");

            if (client.TryReceiveFrameString(timeout, out message)){
              // Server is online
              Bpm.bpmValue = message;
              Debug.Log("Received: " + message);
            }
            else {
              // Server is down
              Debug.Log("Server is down");
            }

        }

        NetMQConfig.Cleanup(); // this line is needed to prevent unity freeze after one use, not sure why yet
    }
}
