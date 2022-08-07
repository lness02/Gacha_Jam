using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpShooter : Shooter
{
    public enum POP_DIRECTIONS {up, down, left, right};
    [SerializeField] POP_DIRECTIONS dir = POP_DIRECTIONS.up;
    [SerializeField] float popSpeed = 0.05f;

    private int ydir, xdir;
    private float length;

    void Start()
    {
        ydir = dir == POP_DIRECTIONS.up ? 1 : dir == POP_DIRECTIONS.down ? -1 : 0;
        xdir = dir == POP_DIRECTIONS.right ? 1 : dir == POP_DIRECTIONS.left ? -1 : 0;
        if(ydir == 0)
            length = this.GetComponent<SpriteRenderer>().size.x;
        else
            length = this.GetComponent<SpriteRenderer>().size.y;
        StartCoroutine(popShoot());
    }

    private IEnumerator popShoot()
    {
        yield return StartCoroutine(waitForPlayer());
        yield return StartCoroutine(pop(true));
        this.transform.rotation = Quaternion.Euler(0, 0, aim());
        shoot();
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        yield return StartCoroutine(pop(false));
    }

    private IEnumerator pop(bool inScreen)
    {
        Debug.Log("called");
        yield return new WaitForSeconds(1);
        for (float i = 0; i < length; i += popSpeed)
        {
            Vector3 change = new Vector3(xdir, ydir, 0) * popSpeed;
            this.transform.position += inScreen ? change : -change;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator waitForPlayer()
    {
        float dist = 11;
        Vector2 start = this.transform.position + new Vector3(xdir, ydir, 0) * length;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 end = player.transform.position;
        while (dist > 10 || Physics2D.Linecast(start, end).collider.gameObject.layer != 3)
        {
            end = player.transform.position;
            dist = Vector2.Distance(start, end);
            yield return null;
        }
    }
}
