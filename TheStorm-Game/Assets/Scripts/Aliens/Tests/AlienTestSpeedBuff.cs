using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Test Alien Speed Buff
/// </summary>
public class AlienTestSpeedBuff : AlienBuff
{

    /***** Public Variables *****/
    public int buffAmount = 4;

    public void Start()
    {
        buffAmount = Random.Range(1, 5);
    }

    /// <summary>
    /// Applies the buff to the player.
    /// </summary>
    public override void ApplyBuff()
    {

        base.ApplyBuff();

        print(buffAmount);

        player.GivePermSpeedBuff(buffAmount);
    }

    public override void RemoveBuff()
    {
        base.RemoveBuff();

        player.GivePermSpeedBuff(-buffAmount);
    }
}
