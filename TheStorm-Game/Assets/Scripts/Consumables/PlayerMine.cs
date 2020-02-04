using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Consumable
{
    public override void useItem()
    {
        print("Place mine");

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
