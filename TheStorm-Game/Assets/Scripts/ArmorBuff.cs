﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBuff : Buff
{
    public override void GiveBuff()
    {
        //give player buff here
        print("In Armor Buff");
        base.GiveBuff();
    }
}
