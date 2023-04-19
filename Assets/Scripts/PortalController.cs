using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public int nextLevel; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().CompareTag("Player"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
