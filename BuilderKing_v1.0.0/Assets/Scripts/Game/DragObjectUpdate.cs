using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectUpdate : MonoBehaviour
{

    public Camera cam = Camera.main;
    public static Transform rock;
    public float distanceFromCamera;
    public float maxVel = 30;
    Rigidbody rb;

    void OnMouseDown() {
      rock = null;
      rock = gameObject.transform;
      Debug.Log("--> " + rock);
      rb = rock.GetComponent<Rigidbody>();
      rb.constraints = RigidbodyConstraints.FreezeRotation;
      rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);
      distanceFromCamera = Vector3.Distance(rock.position, cam.transform.position);
      Debug.Log("dist :"+distanceFromCamera);
      // Timer on
      Timer.StartTimer();
      Debug.Log("START-------->"+Timer.startTime);
    }

    void OnMouseUp(){
      rb.constraints = RigidbodyConstraints.None;
      rb = null;
      rb.velocity = Vector3.zero;
      distanceFromCamera = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if (rock != null) {
        if (Input.GetMouseButton(0)) {
          Vector3 pos = Input.mousePosition;
          pos.z = distanceFromCamera;
          pos = cam.ScreenToWorldPoint(pos);
          rb.velocity = (pos-rock.position)*30;
        }
      }
    }
}
