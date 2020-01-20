using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    public GameObject secondaryWeapon;
    public GameObject healthSlider;
    public GameObject armorSlider;
    public float armor;
    public float maxArmorValue;
    public float speedBuffAmount;
    public float speedBuffTime;
    private float speedBuffStartTime;
    [Header("Player Attributes")]
    public float rotationSpeed;
    [Header("PLayer Sprites")]
    public Sprite facingFront, facingLeft, facingRight, facingAway;

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((speedBuffTime > 0) && (Time.time > (speedBuffStartTime + speedBuffTime)))
        {
            print("Removing Speed Buff");
            speed -= speedBuffAmount;
            speedBuffAmount = 0;
            speedBuffTime = 0;
        }

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
        Rotate();
        // PLAYER MOVEMENT //
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(h, 0, v);
        //movement.Normalize();
        //movement *= (speed * Time.deltaTime);

        //transform.Translate(movement);
        //gameObject.transform.position += new Vector3(h, 0, v).normalized * speed;
        gameObject.GetComponentInParent<Transform>().parent.position += new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
    }

    private void Rotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Vector3 hitPoint = hit.point;

            //transform.LookAt(hitPoint);
            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

            Vector3 directionToMouse = (hitPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToMouse);
            lookRotation.x = 0;
            lookRotation.z = 0;
            //lookRotation.SetEulerAngles(0, lookRotation.eulerAngles.y, 0);
            //Quaternion.Euler
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        if(transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 45)
        {
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingAway;
        }
        else if(transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 135)
        {
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingRight;
        }
        else if(transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 225)
        {
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingFront;
        }
        else
        {
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingLeft;
        }
        //print(transform.rotation.eulerAngles.y);
    }

    public void PickupWeapon(GameObject newWeapon)
    {
        if (equippedWeapon != null)
        {
            Debug.Log("First Check");
            if (secondaryWeapon == null)
            {
                Debug.Log("Second Check");
                secondaryWeapon = equippedWeapon;
                Inventory.instance.SetWeaponSlots(null, weapon.weaponSprite);
            }
            else
            {
                Destroy(equippedWeapon);
            }
        }

        equippedWeapon = Instantiate(newWeapon, transform) as GameObject;

        weapon = equippedWeapon.GetComponent<Weapon>();
        weapon.setOwnerTag(tag);

        Inventory.instance.SetWeaponSlots(weapon.weaponSprite, null);
    }

    public void SwapWeapons()
    {
        var temp = equippedWeapon;
        equippedWeapon = secondaryWeapon;
        secondaryWeapon = temp;

        if (secondaryWeapon != null)
        {
            Inventory.instance.SetWeaponSlots(null, weapon.weaponSprite);
        }

        if (equippedWeapon != null)
        {
            weapon = equippedWeapon.GetComponent<Weapon>();
            weapon.setOwnerTag(tag);

            Inventory.instance.SetWeaponSlots(weapon.weaponSprite, null);
        }
    }

    public override void TakeDamage(float damage)
    {
        float totalDamage = damage;
        if(armor > 0)
        {
            if (damage <= armor)
            {
                armor -= damage;
                totalDamage = 0;
            }
            else
            {
                totalDamage = damage - armor;
                armor = 0;
                armorSlider.SetActive(false);
            }

            if(armor == 0)
                armorSlider.SetActive(false);
        }
        base.TakeDamage(totalDamage);
        healthSlider.gameObject.GetComponent<Slider>().value = health;
    }

    public void GiveHealth(float health)
    {
        if (this.health < playerMaxHealth)
        {
            print("Giving health");
            this.health += health;
            healthSlider.gameObject.GetComponent<Slider>().value = this.health;
        }
    }

    public void GiveArmor(float armor)
    {
        //if(armor == 0)
        //{
            armorSlider.SetActive(true);
        //}

        if(armor < maxArmorValue)
        {
            print("Giving Armor");
            this.armor += armor;
            armorSlider.gameObject.GetComponent<Slider>().value = this.armor;
        }
    }

    public void GiveSpeedBuff(float amount, float duration)
    {
        if(speedBuffAmount > 0)
        {
            speed -= speedBuffAmount;
            speedBuffAmount = 0;
            speedBuffTime = 0;
        }

        speed += amount;
        speedBuffAmount = amount;
        speedBuffTime = duration;
        speedBuffStartTime = Time.time;
    }
}
