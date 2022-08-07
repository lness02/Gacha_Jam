using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public float aim()
    {
        Vector3 target = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (this.gameObject.tag == "Player")
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target -= this.transform.position;
        target.Normalize();
        return Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
    }

    public void shoot()
    {
        Instantiate(bullet, this.transform, false);
    }
}
