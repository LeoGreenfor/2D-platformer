using Assets.Scripts.NewGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool isOnWater;
    public int health = 20;

    private Vector2 startPosition = new Vector2(-20, 2);
    public PlayerMemento playerMemento;
    private PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerMemento = SaveState();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DeathByWater()
    {
        if (PlayerAbilities.SpriteNumber == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        RestoreState(playerMemento);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = startPosition;
    }
    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public PlayerMemento SaveState()
    {
        return new PlayerMemento(health, stats.fire, startPosition);
    }
    public void RestoreState(PlayerMemento memento)
    {
        health = memento.Lives;
        stats.fire = memento.Fireballs;
        startPosition = memento.StartPosition;
    }

}
