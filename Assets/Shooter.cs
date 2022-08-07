using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public float aim()
    {
        if (this.gameObject.tag == "Player")
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
            difference.Normalize();
            return Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
        else
            return Vector2.SignedAngle(GameObject.FindGameObjectWithTag("Player").transform.position,
                this.transform.position);
    }

    public void shoot()
    {
        Instantiate(bullet, this.transform, false);
    }
}
