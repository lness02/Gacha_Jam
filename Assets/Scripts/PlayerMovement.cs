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
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fly();
        Debug.Log(this.grounded());
        if(this.grounded())
            move();
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
    }

    private void move()
    {
        int dir = Input.GetKey(KeyCode.A) ? -1 : 0;
        dir += Input.GetKey(KeyCode.D) ? 1 : 0;
        rb.velocity = (Vector2.right * dir * moveSpeed);
        if (Input.GetKey(KeyCode.W))
            rb.velocity += Vector2.up * jump;
    }

    private bool grounded()
    {
        return Physics2D.Raycast(this.transform.position, Vector3.down,
            this.GetComponent<SpriteRenderer>().size.y/2 + 0.1f, ~(1 << 3));
    }
}
