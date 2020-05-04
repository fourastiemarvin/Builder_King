using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectUpdate : MonoBehaviour
{

    public Camera cam;
    public static Transform rock;
    public float distanceFromCamera;
    public float maxVel = 30;
    Rigidbody rb;

    void OnMouseDown() {
      rock = null;
      rock = gameObject.transform;
      rb = rock.GetComponent<Rigidbody>();
      rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVel);
      distanceFromCamera = Vector3.Distance(rock.position, cam.transform.position);
    }

    void OnMouseUp(){
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
