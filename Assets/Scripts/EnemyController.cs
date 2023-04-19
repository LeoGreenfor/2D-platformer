using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Propertys

    public int Damage;
    private float speed = 0.01f;
    private float speedToFight = 0.04f;
    public int health;

    //if false - patrol
    //if true - fight
    public bool stateToFight = false;
    public bool isCanAttack = true;

    public Vector3 leftPoint;
    public Vector3 rightPoint;
    public Vector3 currentPoint;

    public float distanceToFight;
    public float distanceToAttack;
    private int culldown = 2;

    public Transform player;
    private Rigidbody2D rigidbody2D;

    #endregion

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentPoint = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < distanceToFight)
        {
            stateToFight = true;
        }
        else
        {
            stateToFight = false;
        }

        if (Vector3.Distance(transform.position, player.position) < distanceToAttack)
        {
            if (isCanAttack)
            {
                rigidbody2D.AddForce(player.position * 0.2f, ForceMode2D.Impulse);
                player.GetComponent<PlayerHealth>().Damage(Damage);
                isCanAttack = false;

            }
        }
        if (!isCanAttack)
        {
            StartCoroutine(nameof(Culldown));
        }
    }

    public IEnumerator Culldown()
    {
        yield return new WaitForSeconds(2f);
        isCanAttack = true;
    }
    
    private void FixedUpdate()
    {
        if (stateToFight)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speedToFight);

            if (transform.position.x < player.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (transform.position.x > player.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }

        } else
        {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint, speed);

            if (transform.position == leftPoint)
            {
                currentPoint = rightPoint;
                transform.localScale = new Vector2(-1, 1);
            }
            else if (transform.position == rightPoint)
            {
                currentPoint = leftPoint;
                transform.localScale = new Vector2(1, 1);
            }

        }

    }
}
