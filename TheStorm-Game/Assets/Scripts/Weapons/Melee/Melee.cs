using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [Header("Melee Attributes")]
    public float swingTime;
    public float swingAngle;

    private bool rightSide;
    private float swingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(swingTime > fireRate)
        {
            swingTime = fireRate;
        }
        
        rightSide = true;

        swingSpeed = swingAngle / swingTime;

        transform.Rotate(0, swingAngle / 2, 0);
    }

    protected override void Fire()
    {
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        float swungAmount = 0;

        while(swungAmount < swingAngle)
        {
            float swingDelta = swingSpeed * Time.deltaTime;

            if (swingAngle - swungAmount < swingDelta)
            {
                swingDelta = swingAngle - swungAmount;
            }

            swungAmount += swingDelta;

            if (rightSide)
            {
                swingDelta *= -1;
            }

            transform.Rotate(0, swingDelta, 0);

            yield return null;
        }

        rightSide = !rightSide;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Melee Trigger!");

        //if the melee hits a target
        if (other.tag.Equals("Target"))
        {
            Debug.Log("Hit Target");
            other.GetComponent<Target>().TargetHit();
        }

        //If the melee hits a character
        if (other.tag.Equals("Enemy") || other.tag.Equals("Player"))
        {
            if (!other.tag.Equals(ownerTag))
            {
                //call the hit method
                hit(other.gameObject);
            }
            else
            {
                Debug.Log("Hit Self");
                return;
            }
        }
    }

    /// <summary>
    /// Called when the melee hits a character.
    /// </summary>
    /// <param name="o">The gameobject of the character hit</param>
    protected virtual void hit(GameObject o)
    {
        Debug.Log("Melee hit!");

        if (o.tag.Equals("Player"))
        {
            o.GetComponentInChildren<Character>().TakeDamage(damage);
        }
        else
        {
            o.GetComponent<Character>().TakeDamage(damage);
        }
    }
}
