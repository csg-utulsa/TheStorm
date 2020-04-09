using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Gun : Gun
{
    [Header("Running Gun Attributes")]
    public float spreadAngle;
    public int shotsPerSpread;

    [Header("Jump Gun Attributes")]
    public int numShots;

    private float currentAngle;
    private float anglePerShot;
    private int angleChange;

    // Start is called before the first frame update
    void Awake()
    {
        inaccuracy = 0;
        currentAngle = -spreadAngle / 2;
        anglePerShot = spreadAngle / shotsPerSpread;
        angleChange = 1;
    }

    protected override void Fire()
    {
        base.SpawnBullet(currentAngle);

        currentAngle += anglePerShot * angleChange;

        if (currentAngle >= spreadAngle / 2 || currentAngle <= -spreadAngle / 2)
        {
            angleChange *= -1;
        }

        playAudio();
    }

    public void JumpGun()
    {
        float bulletAngle = 0;

        for(int i = 0; i < numShots; i++)
        {
            base.SpawnBullet(bulletAngle);

            bulletAngle += 360 / numShots;
        }
    }

    public override void StopFiring()
    {
        base.StopFiring();

        currentAngle = -spreadAngle / 2;
        angleChange = 1;
    }
}
