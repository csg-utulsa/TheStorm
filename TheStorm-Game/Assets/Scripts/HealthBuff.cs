using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuff : Buff
{
    public override void GiveBuff()
    {
        //give player buff here
        print("In Health Buff");
        base.GiveBuff();
    }
}
