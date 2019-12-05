using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTester : MonoBehaviour
{
    public GameObject equippedWeapon;

    private Weapon weapon;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if(child.tag.Equals("Weapon")||child.tag.Equals("Gun"))
            {
                equippedWeapon = child;
                break;
            }
            else if(i == transform.childCount-1)
            {
                Debug.Log("No starting Weapon");
                return;
            }
        }
        
        weapon = equippedWeapon.GetComponent<Weapon>();
        Debug.Assert(weapon != null, "Weapon is null");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.StartFiring();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            weapon.StopFiring();
        }
    }

    public void EquipWeapon(GameObject newWeapon)
    {
        Destroy(equippedWeapon);

        equippedWeapon = Instantiate(newWeapon, transform);

        weapon = equippedWeapon.GetComponent<Weapon>();
    }
}
