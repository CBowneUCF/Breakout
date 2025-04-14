using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sprite; //Doesn't need to be Property, just make private field.
    public Color[] states;
    private int health; //Doesn't need to be Property, just make private field.

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>(); 
        GameManager.bricksLeft++;
        health = states.Length;
        sprite.color = states[health - 1];
    }
    //Separate Start and Awake serve no purpose here.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Separate function call not needed, also since these bricks don't move, nothing besides the ball can collide with them.
        health--;
        if (health <= 0) gameObject.SetActive(false);
        else sprite.color = states[health - 1];
        GameManager.instance.BrickHit(health <= 0);
        //FindObjectOfType<Ball>().Hit(); ---- This is genuinely like the worst possible way to do this.
    }

    //Whats with all the "this" indirection? I don't even know if that's inefficient it's just unecessary and visually obnoxious.
}
