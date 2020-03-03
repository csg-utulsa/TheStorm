using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMine : Consumable
{
    public GameObject mine;

    public override void useItem()
    {
        print("Place mine");

        GameObject newobj = Instantiate(mine);
        newobj.transform.position = GameObject.Find("Player").gameObject.transform.position;
        newobj.transform.position.Set(newobj.transform.position.x+1, newobj.transform.position.y, newobj.transform.position.z);

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
