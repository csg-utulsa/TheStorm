using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Player : Character
{
    public GameObject secondaryWeapon;
    [Header("Buff Attributes")]
    public GameObject armorSlider;
    public float startingArmor;
    public float maxArmor;
    public float speedBuffAmount = 0;
    public float speedBuffTime;
    private float speedBuffStartTime;
    [Header("Player Attributes")]
    public float rotationSpeed;
    public GameObject deathScreen;
    [Header("Player Sprites")]
    public Sprite facingFront;
    public Sprite facingLeft;
    public Sprite facingRight;
    public Sprite facingAway;

    private float armor;
    private Slider armorBar;

    // Input
    private PlayerInput playerInput;

    // Movement
    private Vector2 i_movement = Vector2.zero;

    protected void Awake()
    {
        armorBar = armorSlider.GetComponent<Slider>();
        armor = startingArmor;
        armorBar.maxValue = maxArmor;
        armorBar.value = armor;

        playerInput = GetComponent<PlayerInput>();
    }

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
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartAttack();
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    StopAttack();
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    StopAttack();
        //    SwapWeapons();
        //}
    }

    void OnMove(InputValue value)
    {

        i_movement = value.Get<Vector2>();

    }

    void OnSwapWeapons(InputValue value)
    {

        Debug.Log("Q pressed");

    }

    void OnFire()
    {

        Debug.Log("Fire");

    }

    protected override void Move()
    {
        Rotate();
        if (i_movement != Vector2.zero)
        {
            transform.parent.position += new Vector3(i_movement.x, 0, i_movement.y).normalized * speed * Time.deltaTime;
            //agent.SetDestination(transform.position + new Vector3(h, 0, v).normalized * speed * Time.deltaTime);
        }
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
        //If the player already has an equipped weapon
        if (equippedWeapon != null)
        {
            //If their secondary slot is available
            if (secondaryWeapon == null)
            {
                //Add this new weapon as a secondary
                secondaryWeapon = Instantiate(newWeapon, transform) as GameObject;
                //Update the weapon inventory GUI
                Inventory.instance.SetWeaponSlots(null, secondaryWeapon.GetComponent<Weapon>().weaponSprite);
                //Done with weapon pickup
                return;
            }
            //If it is not available
            else
            {
                //Destroy the currently equipped weapon
                Destroy(equippedWeapon);
            }
        }

        //Spawn this new weapon as the equipped weapon
        equippedWeapon = Instantiate(newWeapon, transform) as GameObject;

        //Store the equipped weapon objects script
        weapon = equippedWeapon.GetComponent<Weapon>();
        //Set the tag of the weapon to this tag
        weapon.setOwnerTag(tag);

        //Update the weapon inventory GUI
        Inventory.instance.SetWeaponSlots(weapon.weaponSprite, null);
    }

    public void SwapWeapons()
    {
        //Swap the two weapons
        var temp = equippedWeapon;
        equippedWeapon = secondaryWeapon;
        secondaryWeapon = temp;

        //If the secondary weapon is not null
        if (secondaryWeapon != null)
        {
            //update the GUI
            Inventory.instance.SetWeaponSlots(null, weapon.weaponSprite);
        }
        else
        {
            Inventory.instance.ClearWeaponSlots(false, true);
        }

        //if there is an equipped weapon
        if (equippedWeapon != null)
        {
            //Update the equipped weapon script
            weapon = equippedWeapon.GetComponent<Weapon>();
            weapon.setOwnerTag(tag);
            //Update the GUI
            Inventory.instance.SetWeaponSlots(weapon.weaponSprite, null);
        }
        else
        {
            Inventory.instance.ClearWeaponSlots(true, false);
        }
    }

    public override void TakeDamage(float damage)
    {
        float armoredDamage = damage - armor;

        Debug.Log("Health: {health}\nArmor: {armor}\nDamage: {damage}\nAdjusted Damage: {armoredDamage}");

        if (armoredDamage <= 0)
        {
            armor = -armoredDamage;
            armorBar.value = armor;
        }
        else
        {
            armor = 0;
            armorBar.value = armor;
            armorSlider.SetActive(false);

            base.TakeDamage(armoredDamage);
        }
    }

    public void GiveArmor(float amount)
    {
        armorSlider.SetActive(true);

        float armorDif = maxArmor - armor;

        if (amount < armorDif)
        {
            print("Giving armor");
            armor += amount;
        }
        else
        {
            armor = maxArmor;
        }

        armorBar.value = armor;
    }

    public void GiveSpeedBuff(float amount, float duration)
    {
        if(speedBuffAmount > 0)
        {
            speed -= speedBuffAmount;
            speedBuffAmount = 0;
            speedBuffTime = 0;
        }

        print("speed beeore = " + (speed));
        print("speed after = " + (speed + amount));

        speed += amount;
        speedBuffAmount = amount;
        speedBuffTime = duration;
        speedBuffStartTime = Time.time;
    }

    /// <summary>
    /// Gives a permanent speed buff
    /// </summary>
    /// <param name="amount">The amount to buff</param>
    public void GivePermSpeedBuff(float amount)
    {
        speed += amount;
    }

    /// <summary>
    /// Increases the max health of the player.
    /// </summary>
    /// <param name="amount">The amount to increase.</param>
    public void IncreaseMaxHealth(float amount)
    {

        maxHealth += amount;
        healthBar.maxValue = maxHealth;

    }

    protected override void Die()
    {
        deathScreen.gameObject.SetActive(true);
        //base.Die();
    }
}
