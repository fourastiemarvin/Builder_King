using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float minY = 0.0f, maxY = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Vector3 currentPosition = transform.position;
      currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
      transform.position = currentPosition;

      if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
        transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
      }
      else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
        transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
      }

      if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
        transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
      }
      else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
        transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
      }

      if (Input.GetKey("q")) {
        transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
      }
      else if (Input.GetKey("e")) {
        transform.position -= transform.TransformDirection(Vector3.up) * Time.deltaTime * movementSpeed;
      }


      // FIXME: rotate the player with the camera
      //transform.Rotate(Camera.main.transform.up, Input.GetAxis("Mouse X"));

    }
}
