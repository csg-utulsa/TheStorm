using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [Header("Shotgun Attributes")]
    public int numPellets;
    public float rangeModifier;

    private float defaultRange;
    private float defaultSpeed;

    private void Awake()
    {
        defaultRange = range;
        defaultSpeed = bulletVelocity;
    }

    /// <summary>
    /// Fires a number of bullets specified above
    /// The first half have an inaccuracy 1/2 that
    /// given to the gun
    /// </summary>
    protected override void Fire()
    {
        for(int i = 0; i < numPellets; i++)
        {
            float spread;
            float rangeChange;

            if(i < numPellets/2)
            {
                spread = .25f;
            }
            else
            {
                spread = .5f;
            }

            rangeChange = 1 + Random.Range(-rangeModifier / 2, rangeModifier / 2);

            range *= rangeChange;
            bulletVelocity *= rangeChange;

            float spreadAngle = Random.Range(-inaccuracy * spread, inaccuracy * spread);

            base.SpawnBullet(spreadAngle);

            range = defaultRange;
            bulletVelocity = defaultSpeed;
        }

        playAudio();
    }
}
