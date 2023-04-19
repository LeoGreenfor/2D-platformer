using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.1f;
    [HideInInspector]
    public bool isGrounded;

    public Rigidbody2D rigidbody2;
    private SpriteRenderer spriteRenderer;
    public GameObject secondPlayer;
    private PlayerStats stats;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stats = GetComponent<PlayerStats>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        Movement();
        FlipX();
    }

    private void FlipX()
    {
        if (Input.GetAxis("Horizontal") < 0)
            transform.localScale = new Vector2(-1, 1);
        else if (Input.GetAxis("Horizontal") > 0)
            transform.localScale = new Vector2(1, 1);
    }

    private void Animation()
    {
        if (PlayerAbilities.SpriteNumber == 0)
        {
            if (!isGrounded)
            {
                animator.Play("Jump");
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.speed = 0.5f;
            }
            else
            {
                animator.speed = 1;
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        else
        {
            if (!isGrounded)
            {
                animator.Play("BlueJump");
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.Play("BlueCtrl");
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.Play("BlueRun");
            }
            else
            {
                animator.Play("BlueIdle");
            }
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = stats.SpeedRun;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = stats.SpeedCtrl;
        }
        else
        {
            speed = stats.SpeedWalk;
        }


        float x_position = transform.position.x + Input.GetAxis("Horizontal") * speed;
        transform.position = new Vector3(x_position,
            transform.position.y, transform.position.z);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2.AddForce(transform.up * stats.JumpForce, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
        Jump();
    }
}
