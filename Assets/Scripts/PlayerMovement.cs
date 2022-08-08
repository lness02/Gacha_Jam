using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jump = 1000;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float scanDistance = 2;

    private Rigidbody2D rb;
    public bool facingRight = true;
    private bool grounded;
    private Collider2D selected = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Raycast(this.transform.position, Vector2.down,
            this.GetComponent<Collider2D>().bounds.size.y / 2 + 0.2f, ~(1 << 3));
        if (grounded)
        {
            Globals.PLAYER_HEALTH--;
            rb.rotation = 0;
            rb.angularVelocity = 0;
            move();
        }
        else
        {
            if (facingRight && rb.velocity.x < -0.1 || !facingRight && rb.velocity.x > 0.1)
            {
                facingRight = !facingRight;
                Vector3 scale = this.transform.localScale;
                scale.x *= -1;
                this.transform.localScale = scale;
            }
        }

        Collider2D col = scanInteractable();
        if (selected != null && selected != col)
            selected.GetComponent<Interactable>().deselect();
        selected = col;
        if (selected != null)
        {
            selected.GetComponent<Interactable>().select();
            if(Input.GetKeyDown(KeyCode.E))
                selected.GetComponent<Interactable>().interact();
        }
    }

    private void move()
    {
        int dir = Input.GetKey(KeyCode.A) ? -1 : 0;
        dir += Input.GetKey(KeyCode.D) ? 1 : 0;
        rb.velocity = (Vector2.right * dir * moveSpeed);
        if (Input.GetKey(KeyCode.W))
            rb.velocity += Vector2.up * jump;
        if (facingRight && dir == -1 || !facingRight && dir == 1)
        {
            facingRight = !facingRight;
            Vector3 scale = this.transform.localScale;
            scale.x *= -1;
            this.transform.localScale = scale;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(rb.rotation) > 60)
            Globals.PLAYER_HEALTH--;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    private Collider2D scanInteractable()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, scanDistance, 1 << 6);
        Collider2D best = null;
        float closestDist = scanDistance * scanDistance;
        foreach (Collider2D col in colliders)
        {
            Vector2 diff = col.transform.position - this.transform.position;
            float dist = diff.sqrMagnitude;
            if (dist < closestDist)
            {
                closestDist = dist;
                best = col;
            }
        }
        return best;
    }
}
