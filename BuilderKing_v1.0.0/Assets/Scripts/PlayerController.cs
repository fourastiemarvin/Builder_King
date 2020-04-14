using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // FORWARD WALKING
      if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
        anim.SetBool("isWalking", true);
      }
      else {
        anim.SetBool("isWalking", false);
      }

      // BACKWARD WALKING
      if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
        anim.SetBool("isBackwardWalking", true);
      }
      else {
        anim.SetBool("isBackwardWalking", false);
      }

      // LEFT WALKING
      if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
        anim.SetBool("isLeftWalking", true);
      }
      else {
        anim.SetBool("isLeftWalking", false);
      }

      // RIGHT WALKING
      if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
        anim.SetBool("isRightWalking", true);
      }
      else {
        anim.SetBool("isRightWalking", false);
      }

      // SELECTING OBJECT
      if (Input.GetMouseButton(0)) {
        anim.SetBool("isSelecting", true);
      }
      else {
        anim.SetBool("isSelecting", false);
      }
    }
}
