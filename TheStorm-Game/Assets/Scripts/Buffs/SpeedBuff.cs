using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    public override void GiveBuff()
    {
        //give player buff here
        print("In Speed Buff");
        GameObject player = GameObject.Find("Player");
        player.GetComponentInChildren<Player>().GiveSpeedBuff(2, 10);
        base.GiveBuff();
    }
}
