using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    public override void GiveBuff()
    {
        //give player buff here
        print("In Speed Buff");
        base.GiveBuff();
    }
}
