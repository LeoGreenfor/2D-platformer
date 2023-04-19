using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionController : MonoBehaviour
{
    public Transform player;
    //NavMeshAgent agent;
    private Vector2 newPosition;
    public Vector3 checkPosition;

    public float offset = 1f;
    public float speed = 0.09f;
    public bool isGrounded;
    public bool isMove = false;

    private Rigidbody2D rigidbody2;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;

    }
    private void FixedUpdate()
    {
        FlipX();

        newPosition = player.position;
        newPosition.y += offset;

        if (player.localScale.x == 1)
        {
            newPosition.x -= offset;
        }
        else if (player.localScale.x == -1)
        {
            newPosition.x += offset;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed);
    }
    private void FlipX()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void Animation()
    {
        animator.SetBool("isMove", isMove);
    }

    private void Update()
    {
        //Animation();
        /*if (player.position.y > transform.position.y)
        {
            if (isGrounded)
            {
                rigidbody2.AddForce(transform.up, ForceMode2D.Impulse);
            }
        }
        agent.SetDestination(player.position);*/

        if (transform.position == checkPosition)
        {
            animator.SetBool("isMove", false);
            isMove = false;
        }
        else
        {
            animator.SetBool("isMove", true);
            isMove = true;
        }

        checkPosition = transform.position;
    }

}
