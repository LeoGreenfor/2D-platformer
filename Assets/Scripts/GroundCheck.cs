using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = transform.parent.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController.isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerController.isGrounded = false;
    }
}
