using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTester : MonoBehaviour
{
    public Gun equippedGun;
    private Gun gun;

    private void Start()
    {
        gun = GetComponent<Gun>();

        BulletTypes temp;

        gun.setValues(equippedGun.getValues(out temp), temp);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gun.startFiring();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            gun.stopFiring();
        }
    }
}
