using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlantController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>()
                .rigidbody2
                .AddForce(transform.up * 6, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       collision.gameObject.GetComponent<PlayerStats>().isJumpByPlant = false;
    }
}
