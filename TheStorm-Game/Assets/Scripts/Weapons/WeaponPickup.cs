using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : Pickup
{
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        Sprite weaponSprite = weapon.GetComponent<Weapon>().weaponSprite;
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = weaponSprite;
        }   
    }

    protected override void PickUp()
    {
        player.GetComponent<Player>().PickupWeapon(weapon);
        Destroy(gameObject);
    }
}
