using System.Collections;
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
    void Start()
    {
        defaultInaccuracy = inaccuracy;
        inaccuracyPerBullet = (maxInaccuracy - inaccuracy) / shotsToMaxInacc;
    }

    protected override void Fire()
    {
        inaccuracy += inaccuracyPerBullet;

        base.Fire();
    }

    public override void StopFiring()
    {
        base.StopFiring();

        inaccuracy = defaultInaccuracy;
    }
}
