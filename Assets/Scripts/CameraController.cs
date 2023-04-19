using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        transform.position = new Vector3(target.position.x + Input.GetAxis("Horizontal"), 
                                            target.position.y + Input.GetAxis("Vertical"), 
                                            transform.position.z);
    }
}
