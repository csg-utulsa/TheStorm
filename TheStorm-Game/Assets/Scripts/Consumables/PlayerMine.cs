using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Consumable
{
    public GameObject thrownGrenade;

    public override void useItem()
    {
        print("Place mine");

        GameObject newobj = Instantiate(thrownGrenade);
        newobj.transform.position = GameObject.Find("Player").gameObject.transform.position;

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
