using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [Header("Character Attributes")]
    //The max amount of health a character can have
    public float maxHealth;
    //The current health of the character
    public float health;
    //The current moevement speed of the character
    public float speed;
    //The healthbar UI for the character
    public Slider healthBar;
    [Header("NavMesh Agent")]
    public NavMeshAgent agent;
    [Header("Weapons")]
    //The currently equipped weapon of the character
    public GameObject equippedWeapon;
    //The script on the equipped weapon
    protected Weapon weapon;
    
    //The default speed of the character
    private float defaultSpeed;

    //Called after awake
    protected void Start()
    {
        //if there is a parent object
        if(transform.parent !=null)
        {
            // get the attached navmeshagent component from the parent
            agent = transform.parent.GetComponent<NavMeshAgent>();
        }
        else
        {
            //otherwise get the component from this object
            agent = GetComponent<NavMeshAgent>();
        }
        

        Debug.Log("Set Health");
        //Initialize the health and healthbar
        healthBar.maxValue = maxHealth;
        health = maxHealth;
        healthBar.value = health;

        //Find the script for the starting equipped weapon
        SetStartingWeapon();

        //Set the default speed
        defaultSpeed = speed;
        agent.speed = speed;
    }

    /// <summary>
    /// Starts firing the equipped gun
    /// </summary>
    protected virtual void StartAttack()
    {
        Debug.Log("Start Attacking");
        //Only call if there is an equipped weapon
        if (weapon != null)
        {
            Debug.Log("Weapon Check");
            weapon.StartFiring();
        }
    }

    /// <summary>
    /// Stops firing the equipped weapon
    /// </summary>
    protected virtual void StopAttack()
    {
        Debug.Log("Stop Attacking");
        //Only call if there is a weapon equipped
        if (weapon != null)
        {
            weapon.StopFiring();
        }
    }

    /// <summary>
    /// Removes health from the Character
    /// </summary>
    /// <param name="damage">the amount of health to remove</param>
    public virtual void TakeDamage(float damage)
    {
        //Decrease the current health
        health -= damage;

        //Set the healthbar if it exists
        if (healthBar != null)
        {
            healthBar.value = health;
        }

        //Call the die function if the character is out of health
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Restores health to the character
    /// </summary>
    /// <param name="amount">the amount to restore</param>
    public void GiveHealth(float amount)
    {
        //store how much health is missing
        float healthDif = maxHealth - health;

        //If there is more missing than whats being restored
        if (amount < healthDif)
        {
            print("Giving health");
            //Add the amount back to health
            health += amount;
        }
        //If there is less missing than what is being restored
        else
        {
            //set the character to full health
            health = maxHealth;
        }

        //Update the healthbar if it exists
        if(healthBar!=null)
        {
            healthBar.value = health;
        }        
    }

    /// <summary>
    /// Controls moving the character
    /// </summary>
    protected virtual void Move()
    {
        //overloaded by subclasses
    }

    /// <summary>
    /// Called when the character runs out of health
    /// </summary>
    protected virtual void Die()
    {
        //Should be moved to Enemy and Boss Die functions with custom score values
        //This should not be in the base class and should not be hard coded
        FindObjectOfType<Inventory>().UpdateScore(20);

        //If the character script's object has a parent
        if (transform.parent != null)
        {
            //destroy the parent
            Destroy(transform.parent.gameObject);
        }
        else
        {
            //otherwise destroy this object
            Destroy(gameObject);
        }        
    }

    /// <summary>
    /// Adjusts the character's speed for a set duration
    /// </summary>
    /// <param name="mult">what percentage of the current speed is the new speed</param>
    /// <param name="duration">how long to be at the new speed</param>
    public void ChangeSpeed(float mult, float duration)
    {
        //Change the current speed
        speed *= mult;

        //Change the speed of the navmeshagent
        agent.speed = speed;

        //A negative duration is permanent
        if(duration >=0)
        {
            //otherwise reset to the default speed after the duration
            Invoke("ResetSpeed()", duration);
        }
        
    }

    /// <summary>
    /// Resets the movement speed to its default
    /// </summary>
    public void ResetSpeed()
    {
        //Reset the speed
        speed = defaultSpeed;

        //Reset the navmeshagent speed
        agent.speed = speed;
    }

    /// <summary>
    /// Finds the weapon child object and stores it's script
    /// </summary>
    private void SetStartingWeapon()
    {
        //Look through each child object
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            //if the child has a weapon tag
            if (child.tag.Equals("Weapon") || child.tag.Equals("Gun"))
            {
                //set the equipped weapon to this
                equippedWeapon = child;
                //exit the loop
                break;
            }
            //If a weapon isnt found
            else if (i == transform.childCount - 1)
            {
                //Debug and return from the method
                Debug.Log("No starting Weapon");
                return;
            }
        }
        //Set the script of the equipped weapon
        weapon = equippedWeapon.GetComponent<Weapon>();
        //Mke sure the weapon does not hit the same tag it was fired from
        weapon.setOwnerTag(tag);

        //Ensure there is a weapon at this point
        Debug.Assert(weapon != null, "Weapon is null");
    }
}
