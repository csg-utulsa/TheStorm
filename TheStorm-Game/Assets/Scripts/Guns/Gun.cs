using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Fire Rate")]
    public float fireRate;
    [Header("Bullet Attributes")]
    public float damage;
    public float range;
    public float bulletVelocity;
    public BulletTypes bulletType;

    private bool isFiring;
    private float timeSinceLastShot;
    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        timeSinceLastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot <= 0)
        {
            if(isFiring)
            {
                Fire();

                timeSinceLastShot = fireRate;
            }
        }
        else
        {
            timeSinceLastShot -= Time.deltaTime;
        }
    }

    public void StartFiring()
    {
        isFiring = true;
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    protected virtual void Fire()
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, 0);
    }
}
