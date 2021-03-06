﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Gun
{
    [Header("Machine Gun Attributes")]
    //The maximum inaccuracy that can be reached
    public float maxInaccuracy;
    //How many shots it takes to get to the maximum inaccuracy
    public int shotsToMaxInacc;

    private float inaccuracyPerBullet;
    private float defaultInaccuracy;
    // Start is called before the first frame update
    void Awake()
    {
        defaultInaccuracy = inaccuracy;
        inaccuracyPerBullet = (maxInaccuracy - inaccuracy) / shotsToMaxInacc;
        Debug.Log(inaccuracyPerBullet);
    }

    protected override void Fire()
    {
        if(inaccuracy + inaccuracyPerBullet < maxInaccuracy)
        {
            inaccuracy += inaccuracyPerBullet;
        }
        else if (inaccuracy != maxInaccuracy)
        {
            inaccuracy = maxInaccuracy;
        }

        base.Fire();
    }

    public override void StopFiring()
    {
        base.StopFiring();

        inaccuracy = defaultInaccuracy;
    }
}
