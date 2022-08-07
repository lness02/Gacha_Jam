using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : Shooter
{
    private bool reloading = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!reloading)
            StartCoroutine(shoot());
    }

    public IEnumerator shoot()
    {
        base.shoot();
        reloading = true;
        yield return new WaitForSeconds(2);
        reloading = false;
    }
}
