using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxVelocity = 20f;
    
    // Most of this stuff is more suited for a Game Manager, which technically can be fine on a ball like this, but, single responsibility principle.
    //All Methods and Fields more suited to a GameManager have been moved there.

    public Vector3 startVelocity = new(0, -15f, 0);
    public GameObject deathPlane; //DeathPlane object to be collided with.

    private Rigidbody2D rb;
    private Vector3 startPosition = new(0, -5.5f, 0);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
        rb.velocity = Vector2.down * 15;
        startPosition = transform.position; //Set Default Position at start for customizability.
        //Start Velocity must be actual parameter because Velocity can't be set on rigidbody in inspector
    }

    // Update is not needed. See Below.

    //Do DeathPlane by physics rather than checking y position every update.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == deathPlane) GameManager.instance.BallDeath();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        rb.velocity = startVelocity;
    }
}
