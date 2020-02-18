using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Character Attributes")]
    public float maxHealth;
    public float speed;
    public Slider healthBar;
    [Header("Weapons")]
    public GameObject equippedWeapon;

    protected Weapon weapon;
    protected float health;

    protected void Start()
    {
        Debug.Log("Set Health");
        healthBar.maxValue = maxHealth;
        health = maxHealth;
        healthBar.value = health;

        SetStartingWeapon();
    }

    protected virtual void StartAttack()
    {
        Debug.Log("Start Attacking");
        if (weapon != null)
        {
            Debug.Log("Weapon Check");
            weapon.StartFiring();
        }
    }

    protected virtual void StopAttack()
    {
        Debug.Log("Stop Attacking");
        if (weapon != null)
        {
            weapon.StopFiring();
        }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void GiveHealth(float amount)
    {
        float healthDif = maxHealth - health;

        if (amount < healthDif)
        {
            print("Giving health");
            health += amount;
        }
        else
        {
            health = maxHealth;
        }

        healthBar.value = health;
    }

    protected virtual void Move()
    {

    }

    protected virtual void Die()
    {
        FindObjectOfType<Inventory>().UpdateScore(20);

        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
    }

    public void ChangeSpeed(float mult, float duration)
    {
        float defaultSpeed = speed;

        speed *= mult;

        Invoke("ResetSpeed(defaultSpeed)", duration);
    }

    public void ResetSpeed(float defaultSpeed)
    {
        speed = defaultSpeed;
    }

    private void SetStartingWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if (child.tag.Equals("Weapon") || child.tag.Equals("Gun"))
            {
                equippedWeapon = child;
                break;
            }
            else if (i == transform.childCount - 1)
            {
                Debug.Log("No starting Weapon");
                return;
            }
        }

        Debug.Log(tag);

        weapon = equippedWeapon.GetComponent<Weapon>();
        weapon.setOwnerTag(tag);

        Debug.Assert(weapon != null, "Weapon is null");
    }
}
