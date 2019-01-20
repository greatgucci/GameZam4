using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Ground")
        {
            PlayerMoving.instance.jumpCounter = 0;
            PlayerMoving.instance.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            PlayerMoving.instance.isGrounded = false;
        }
    }

}
