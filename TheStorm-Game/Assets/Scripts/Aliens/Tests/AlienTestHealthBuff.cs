using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTestHealthBuff : AlienBuff
{
    
    /***** Public Variables *****/
    public int buffAmount = 5;

    public void Start()
    {
        buffAmount = Random.Range(1, 6);
    }

    /// <summary>
    /// Applies the buff to the player.
    /// </summary>
    public override void ApplyBuff()
    {

        base.ApplyBuff();

        player.IncreaseMaxHealth(buffAmount);
        player.GiveHealth(buffAmount);

    }
    public override void RemoveBuff()
    {
        base.RemoveBuff();

        player.GivePermSpeedBuff(-buffAmount);
    }
}
