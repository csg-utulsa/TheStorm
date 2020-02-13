using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTestHealthBuff : AlienBuff
{
    
    /***** Public Variables *****/
    public int buffAmount = 5;

    /// <summary>
    /// Applies the buff to the player.
    /// </summary>
    public override void ApplyBuff()
    {

        base.ApplyBuff();

        player.IncreaseMaxHealth(buffAmount);
        player.GiveHealth(buffAmount);

    }

}
