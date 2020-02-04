using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Consumable
{
    public override void useItem()
    {
        print("Throw molotov");

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
