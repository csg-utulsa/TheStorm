using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Consumable
{
    public GameObject thrownMolotov;
    public override void useItem()
    {
        print("Throw molotov");

        GameObject newobj = Instantiate(thrownMolotov);
        newobj.transform.position = GameObject.Find("Player").gameObject.transform.position;
        newobj.transform.position.Set(newobj.transform.position.x, newobj.transform.position.y + 2, newobj.transform.position.z);
        newobj.GetComponent<Rigidbody>().velocity = 20 * GameObject.Find("PlayerChild").gameObject.transform.forward;

        selectedConsumable.Remove(this);

        base.useItem();
    }
}
