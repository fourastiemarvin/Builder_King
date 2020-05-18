using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator anim;
    public bool onFly = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // Fix the skin to the container
      transform.localPosition = new Vector3(0.02f, -1, -0.1f);
      transform.localRotation =  Quaternion.identity;

      // if (Application.systemLanguage == SystemLanguage.French) {
      //   // FORWARD WALKING
      //   if (Input.GetKey("z") || Input.GetKey(KeyCode.UpArrow)) {
      //     anim.SetBool("isWalking", true);
      //   }
      //   else {
      //     anim.SetBool("isWalking", false);
      //   }
      //
      //   // BACKWARD WALKING
      //   if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
      //     anim.SetBool("isBackwardWalking", true);
      //   }
      //   else {
      //     anim.SetBool("isBackwardWalking", false);
      //   }
      //
      //   // LEFT WALKING
      //   if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftArrow)) {
      //     anim.SetBool("isLeftWalking", true);
      //   }
      //   else {
      //     anim.SetBool("isLeftWalking", false);
      //   }
      //
      //   // RIGHT WALKING
      //   if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
      //     anim.SetBool("isRightWalking", true);
      //   }
      //   else {
      //     anim.SetBool("isRightWalking", false);
      //   }
      // } else {
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

      // FLYING
      if (PlayerMovement.canFly) {
        anim.SetBool("isFlying", true);
      }
      else {
        anim.SetBool("isFlying", false);
        onFly = false;
      }

      // SELECTING OBJECT
      if (Input.GetMouseButton(0)) {
        anim.SetBool("isWalking", false);
        anim.SetBool("isRightWalking", false);
        anim.SetBool("isLeftWalking", false);
        anim.SetBool("isBackwardWalking", false);
        anim.SetBool("isFlying", false);
        anim.SetBool("isSelecting", true);
      }
      else {
        anim.SetBool("isSelecting", false);
      }
    }
}
