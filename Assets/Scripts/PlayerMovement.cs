using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float accel = 100;
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
        {
            rb.AddForce(Vector2.up * (accel));
            Debug.Log("Pressed");
        }
        int dir = Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        dir += Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        rb.AddForce(Vector2.right * dir * accel / 5);
    }
}
