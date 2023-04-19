using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public List<Sprite> sprites;
    public static byte SpriteNumber { get; set; }
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
    }

    public void ChangeSprite()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            SpriteNumber = (byte)(SpriteNumber == 0 ? 1 : 0);
        }
        
        spriteRenderer.sprite = sprites[SpriteNumber];
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }
}
