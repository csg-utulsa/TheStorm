using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [Header("Shotgun Attributes")]
    public int numPellets;

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

            if(i < numPellets/2)
            {
                spread = .25f;
            }
            else
            {
                spread = .5f;
            }

            float spreadAngle = Random.Range(-inaccuracy * spread, inaccuracy * spread);


            base.SpawnBullet(spreadAngle);
        }
    }
}
