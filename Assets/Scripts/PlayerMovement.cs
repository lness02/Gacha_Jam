using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float accel = 100;
    [SerializeField] float rotateAccel = 0;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Quaternion.Euler(0, 0, rb.rotation) * Vector3.up * accel);
        int dir = Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;
        dir += Input.GetKey(KeyCode.RightArrow) ? -1 : 0;
        if (rotateAccel == 0)
            rb.AddForce(Vector3.left * dir * accel / 5);
        else
            rb.rotation += dir * rotateAccel;
    }
}
