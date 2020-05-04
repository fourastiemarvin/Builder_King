using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    private Vector3 mOffset;
    private float mZCoord;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Called when mouse key is pressed
    void OnMouseDown() {
      mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
      // Store offset = gameObject world pos - mouse world pos;
      mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    // to get mouse position in 3D world
    private Vector3 GetMouseWorldPos() {
      // pixel coordinates (x,y) :  2D world
      Vector3 mousePoint = Input.mousePosition;
      // z coordinates of game object on screen
      mousePoint.z = mZCoord;

      return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    // called when the object is dragged
    void OnMouseDrag() {
      transform.position = GetMouseWorldPos() + mOffset;
      rb.isKinematic = true;
    }

    // called when the mouse key is released
    void OnMouseUp(){
      rb.isKinematic = false;
    }
}
