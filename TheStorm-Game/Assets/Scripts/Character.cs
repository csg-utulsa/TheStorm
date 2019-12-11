using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Character Attributes")]
    public float health;
    public float speed;
    public Slider healthBar;
    [Header("Weapons")]
    public GameObject equippedWeapon;

    private Weapon weapon;

    private void Start()
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

        healthBar.maxValue = health;

        weapon = equippedWeapon.GetComponent<Weapon>();
        Debug.Assert(weapon != null, "Weapon is null");
    }

    protected virtual void StartAttack()
    {
        weapon.StartFiring();
    }

    protected virtual void StopAttack()
    {
        weapon.StopFiring();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if(healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Move()
    {

    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
