using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject secondaryWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopAttack();
        }
    }

    protected override void Move()
    {
        // PLAYER MOVEMENT //
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        movement.Normalize();
        movement *= (speed * Time.deltaTime);

        transform.Translate(movement);
    }

    public void pickupWeapon(GameObject newWeapon)
    {
        if(secondaryWeapon == null)
        {
            secondaryWeapon = equippedWeapon;
        }
        else
        {
            Destroy(equippedWeapon);
        }

        equippedWeapon = Instantiate(newWeapon, transform);

        weapon = equippedWeapon.GetComponent<Weapon>();

        weapon.setBSP(bulletSpawnPoint);
    }
}
