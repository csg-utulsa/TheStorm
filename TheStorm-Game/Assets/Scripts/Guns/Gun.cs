using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
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
                fire();

                timeSinceLastShot = fireRate;
            }
        }
        else
        {
            timeSinceLastShot -= Time.deltaTime;
        }
    }

    public void startFiring()
    {
        isFiring = true;
    }

    public void stopFiring()
    {
        isFiring = false;
    }

    protected virtual void fire()
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, 0);
    }

    public void setValues(float[] values, BulletTypes bt)
    {
        bulletType = bt;
        fireRate = values[0];
        damage = values[1];
        range = values[2];
        bulletVelocity = values[3];
    }

    public float[] getValues(out BulletTypes bulletType)
    {
        bulletType = this.bulletType;
        float[] values = {fireRate, damage, range, bulletVelocity};

        return values;
    }
}
