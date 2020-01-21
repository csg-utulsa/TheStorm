﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Attributes
    private float damage,
        range,
        speed,
        distance;

    private string ownerTag;

    //Initializes attributes
    public void initialize(float d, float r, float s, string ot)
    {
        damage = d;
        range = r;
        ownerTag = ot;
        speed = s;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate how far the bullet moves this frame
        float moveAmt = speed * Time.deltaTime;
        //Move it forward that amount
        transform.Translate(0, 0, moveAmt);
        //Add the distance it moved to the total distance
        distance += moveAmt;
        //If it has moved to its max range
        if(distance >= range)
        {
            //Finish the bullet
            finish();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the bullet hit a character
        if(other.tag.Equals("Enemy") || other.tag.Equals("Player"))
        {
            if(!other.tag.Equals(ownerTag))
            {
                //call the hit method
                hit(other.gameObject);
            }      
            else
            {
                Debug.Log("Hit Self");
            }
        }

        //SPECIFICALLY FOR DEMO
        else if(other.tag.Equals("Target"))
        {
            other.GetComponent<Target>().TargetHit();
        }
        //If the bullet hit something other than a character
        else if(!other.tag.Equals("Bullet"))
        {
            //Finish the bullet
            finish();
        }

        
    }

    /// <summary>
    /// Called when the bullet hits a character.
    /// </summary>
    /// <param name="o">The gameobject of the character hit</param>
    protected virtual void hit(GameObject o)
    {
        if(o.tag.Equals("Player"))
        {
            o.GetComponentInChildren<Character>().TakeDamage(damage);
        }
        else
        {
            o.GetComponent<Character>().TakeDamage(damage);
        }
    }

    /// <summary>
    /// Called when the bullet is finished moving
    /// </summary>
    protected virtual void finish()
    {
        //Destroy the bullet
        Destroy(gameObject);
    }
}
