using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Consumable
{
    public GameObject thrownGrenade;
    public override void useItem()
    {
        print("Throw grenade");

        GameObject newobj = Instantiate(thrownGrenade);
        newobj.transform.position = GameObject.Find("Player").gameObject.transform.position;
        newobj.transform.position.Set(newobj.transform.position.x, newobj.transform.position.y + 2, newobj.transform.position.z);
        newobj.GetComponent<Rigidbody>().velocity = 20*GameObject.Find("PlayerChild").gameObject.transform.forward;

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
