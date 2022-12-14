using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    [SerializeField] float accel = 100;
    [SerializeField] float rotateAccel = 2;
    private Rigidbody2D playerRB;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (playerRB != null) fly();
    }
    private void fly()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            playerRB.AddForce(Quaternion.Euler(0, 0, playerRB.rotation) * Vector3.up * accel);
        int dir = Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;
        dir += Input.GetKey(KeyCode.RightArrow) ? -1 : 0;
        playerRB.rotation += dir * rotateAccel;
        playerRB.rotation /= 1.02f;
    }

    public void attachToPlayer(GameObject obj)
    {
        this.gameObject.layer = 3;
        this.transform.parent = obj.transform;
        this.transform.localPosition = new Vector3(0.3f, 0.7f, 10);
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        playerRB = obj.GetComponent<Rigidbody2D>();
    }
}
