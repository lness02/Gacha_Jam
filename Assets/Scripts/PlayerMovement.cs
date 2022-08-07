using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float accel = 100;
    [SerializeField] float rotateAccel = 0;
    [SerializeField] float jump = 1000;
    [SerializeField] float moveSpeed = 10;

    private Rigidbody2D rb;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fly();
        if (grounded)
        {
            Globals.PLAYER_HEALTH--;
            rb.rotation = 0;
            move();
        }
        if (Input.GetKeyDown(KeyCode.E))
            this.GetComponent<Shooter>().shoot();
    }

    private void fly()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Quaternion.Euler(0, 0, rb.rotation) * Vector3.up * accel);
        int dir = Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;
        dir += Input.GetKey(KeyCode.RightArrow) ? -1 : 0;
        rb.rotation += dir * rotateAccel;
        rb.rotation /= 1.01f;
    }

    private void move()
    {
        int dir = Input.GetKey(KeyCode.A) ? -1 : 0;
        dir += Input.GetKey(KeyCode.D) ? 1 : 0;
        rb.velocity = (Vector2.right * dir * moveSpeed);
        if (Input.GetKey(KeyCode.W))
            rb.velocity += Vector2.up * jump;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rb.rotation) > 60)
            Globals.PLAYER_HEALTH--;
        grounded = grounded || Physics2D.Raycast(this.transform.position, Vector2.down,
            this.GetComponent<SpriteRenderer>().size.y/2 + 0.1f, ~(1 << 3));
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
