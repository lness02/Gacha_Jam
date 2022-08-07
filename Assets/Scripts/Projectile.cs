using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.parent == null)
            return;

        float angle = this.GetComponentInParent<Shooter>().aim();
        this.transform.rotation = Quaternion.Euler(0, 0, angle);
        this.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, angle) * Vector2.right * speed;
        Destroy(this.gameObject, 2f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (this.transform.parent == other.transform)
            return;
        if (other.gameObject.tag == "Player")
            Globals.PLAYER_HEALTH--;
        Destroy(this.gameObject);
    }
}
