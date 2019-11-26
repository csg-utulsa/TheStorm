using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Gun
{
    [Header("Burst Rifle Attributes")]
    public float burstDelay;
    public int burstNum;

    protected override void Fire()
    {
        StartCoroutine(BurstFire());
    }

    private IEnumerator BurstFire()
    {
        for(int i = 0; i < burstNum; i++)
        {
            base.Fire();

            yield return new WaitForSeconds(burstDelay);
        }
    }
}
