using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;

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

    void OnMouseDrag() {
      transform.position = GetMouseWorldPos() + mOffset;
    }
}
