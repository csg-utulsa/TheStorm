using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTester : MonoBehaviour
{
    public GameObject equippedGun;

    private Gun gun;

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if(child.tag.Equals("Gun"))
            {
                equippedGun = child;
                break;
            }
            else if(i == transform.childCount-1)
            {
                Debug.Log("No starting Gun");
                return;
            }
        }
        
        gun = equippedGun.GetComponent<Gun>();
        Debug.Assert(gun != null, "Gun is null");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            gun.StartFiring();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            gun.StopFiring();
        }
    }

    public void EquipGun(GameObject newGun)
    {
        Destroy(equippedGun);

        equippedGun = Instantiate(newGun, transform);

        gun = equippedGun.GetComponent<Gun>();
    }
}
