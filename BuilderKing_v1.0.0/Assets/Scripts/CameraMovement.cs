using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float mouseSensitivity = 100f;
    public GameObject player;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.Rotate(-Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSensitivity, 0, 0);
        player.transform.Rotate(0,Input.GetAxis("Mouse X")*Time.deltaTime*mouseSensitivity,0);
    }
}
