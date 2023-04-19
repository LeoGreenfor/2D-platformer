using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TMP_Text statsText;
    public float JumpForce;
    public float SpeedRun;
    public float SpeedWalk;
    public float SpeedCtrl;
    public int fire = 10;
    public int numberOfMemory = 0;
    [HideInInspector]
    public bool isJumpByPlant;
    public Transform player;

    private void Update()
    {
        statsText.text = "MEMORIES " + numberOfMemory.ToString() + 
            "\nHEALTH " + player.GetComponent<PlayerHealth>().health.ToString() + "/20";
    }
}
