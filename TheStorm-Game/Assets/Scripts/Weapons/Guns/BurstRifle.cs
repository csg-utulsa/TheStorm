using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Gun
{
    [Header("Burst Rifle Attributes")]
    public float burstDelay;
    public int burstNum;
    public float inaccuracyPerBullet;

    protected override void Fire()
    {
        StartCoroutine(BurstFire());
    }

    private IEnumerator BurstFire()
    {
        float defaultInaccuracy = inaccuracy;

        for(int i = 0; i < burstNum; i++)
        {
            base.Fire();

            inaccuracy += inaccuracyPerBullet;
            playAudio();
            yield return new WaitForSeconds(burstDelay);
        }

        inaccuracy = defaultInaccuracy;
    }
}
