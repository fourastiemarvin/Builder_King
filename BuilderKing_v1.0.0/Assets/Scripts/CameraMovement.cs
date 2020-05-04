using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;
    // set the sensitivity of the mouse
    public float mouseSensitivity = 100f;
    public float RotationSpeed = 100.0f;
    public GameObject player;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
      Debug.Log(Input.mousePosition.x);
      Debug.Log(Input.mousePosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // attach camera to the player
        // Debug.Log(transform.rotation.x);
        // if (transform.rotation.x < -0.45) {
        //   transform.rotation.x = new Vector3(-0.44f, 0, 0);
        // }
        // else if (transform.rotation.x > 0.80) {
        //   transform.rotation.x = new Vector3(0.79f, 0, 0);
        // }
        transform.Rotate(-Input.GetAxis("Mouse Y")*Time.deltaTime*mouseSensitivity*2, 0, 0);

        player.transform.Rotate(0,Input.GetAxis("Mouse X")*Time.deltaTime*mouseSensitivity*3,0);
        //Quaternion CamTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*RotationSpeed, Vector3.up);

    }
}
