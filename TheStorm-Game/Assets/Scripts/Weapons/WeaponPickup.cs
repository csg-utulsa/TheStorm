using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Player>().pickupWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}
