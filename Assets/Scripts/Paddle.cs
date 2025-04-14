using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 15f;
    //public float maxX = 16f;
    //float movementHorizontal;
    Vector3 defaultPosition = new(0, -8, 0);

    private Rigidbody2D rb;

    void Awake()
    {
        defaultPosition = transform.position; //Set defaultPosition for the sake of customizability.
        rb = GetComponent<Rigidbody2D>();
    }

    //Should be Fixed Update
    void FixedUpdate()
    {
        rb.velocity = new(Input.GetAxis("Horizontal") * speed, 0);
        //Doing all this math to get the boundries probably isn't necessary.
        //Idk how naturally expensive the physics is, but I'm assuming using it is less expensive or at the very least less complicated.

        //if((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x > -maxX))
        //{
        //    transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        //}
    }

    public void ResetPosition() => transform.position = defaultPosition;
}
