using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody body;
    PlayerMovement characterInput;
    public float movementSpeed;
    public float minY = 0.0f, maxY = 10.0f;

    // KeyCode to allow fly character
    public KeyCode jumpKey;
    public KeyCode toggleFly;
    public KeyCode flyUpFR;
    public KeyCode flyDownFR;
    public KeyCode flyUpEN;
    public KeyCode flyDownEN;

    public static bool canFly;

    // Start is called before the first frame update
    void Start()
    {
      characterInput = GetComponent<PlayerMovement>();
      body = GetComponent<Rigidbody>();
      body.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 currentPosition = transform.position;
      currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
      transform.position = currentPosition;

      // CANEVA SELECTION KEYBOARD
      // FRENCH KEYBOARD
      if (KeyboardSelector.keyboard == "French") {
        // Move the player forward
        if (Input.GetKey("z") || Input.GetKey(KeyCode.UpArrow)) {
          transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        // Move backward
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
          transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        // Move left
        if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftArrow)) {
          transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        // Move right
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
          transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
      }
      // SWISS KEYBOARD
      else if (KeyboardSelector.keyboard == "SwissUs") {
        // Move the player forward
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
          transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        // Move backward
        else if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
          transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        // Move left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
          transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        // Move right
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
          transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
      }

      // Enable fly
      if (Input.GetKeyDown(characterInput.toggleFly)) {
        Fly();
      }

      // FRENCH KEYBOARD
      if (KeyboardSelector.keyboard == "French") {
        // Move Up
        if (Input.GetKey(characterInput.flyUpFR) && canFly) {
          transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
        // Move down
        if (Input.GetKey(characterInput.flyDownFR) && canFly) {
          transform.position -= transform.up * Time.deltaTime * movementSpeed;
        }
      }
      // SWISS KEYBOARD
      else if (KeyboardSelector.keyboard == "SwissUs") {
        // Move Up
        if (Input.GetKey(characterInput.flyUpEN) && canFly) {
          transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
        // Move down
        if (Input.GetKey(characterInput.flyDownEN) && canFly) {
          transform.position -= transform.up * Time.deltaTime * movementSpeed;
        }
      }


      void Fly() {
        canFly = !canFly;
        body.isKinematic = canFly;
      }

      // Jump
      if (Input.GetKeyDown(KeyCode.Space) && !canFly) {
        body.AddForce(Vector3.up*200);
      }

    }
}
