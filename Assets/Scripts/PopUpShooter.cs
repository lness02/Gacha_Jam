using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpShooter : Shooter
{
    public enum POP_DIRECTIONS {up, down, left, right};
    [SerializeField] POP_DIRECTIONS dir = POP_DIRECTIONS.up;
    [SerializeField] float popSpeed = 0.001f;

    void Start()
    {
        StartCoroutine(popShoot());
    }

    private IEnumerator popShoot()
    {
        yield return StartCoroutine(pop(true));
        this.transform.rotation = Quaternion.Euler(0, 0, aim());
        shoot();
        yield return StartCoroutine(pop(false));
    }

    private IEnumerator pop(bool inScreen)
    {
        yield return new WaitForSeconds(1);
        int ydir = dir == POP_DIRECTIONS.up ? 1 : dir == POP_DIRECTIONS.down ? -1 : 0;
        int xdir = dir == POP_DIRECTIONS.right ? 1 : dir == POP_DIRECTIONS.left ? -1 : 0;
        float length = this.GetComponent<SpriteRenderer>().size.x;
        Debug.Log(length);
        for (float i = 0; i < length; i += popSpeed)
        {
            Vector3 change = new Vector3(xdir, ydir, 0) * popSpeed;
            this.transform.position += inScreen ? change : -change;
            Debug.Log("frame");
            yield return new WaitForFixedUpdate();
        }
    }
}
