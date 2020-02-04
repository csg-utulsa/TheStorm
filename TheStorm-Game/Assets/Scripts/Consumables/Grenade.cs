using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Consumable
{
    public override void useItem()
    {
        print("Throw grenade");

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
