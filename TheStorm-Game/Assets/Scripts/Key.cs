using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    private GameObject playerOne;
    private bool touched;
    private double keyFalling = 1;
    private Vector3 scaleChange = new Vector3(-0.001f, -0.001f, -0.001f);
    private GameObject keyInvetory;
    private GameObject mainInventory;


    private void Start()
    {
        playerOne = GameObject.FindWithTag("Player");
        keyInvetory = GameObject.FindWithTag("Gold Key Updater");
        mainInventory = GameObject.FindWithTag("Inventory");
        touched = false;

    }



    private void OnTriggerEnter(Collider other)
    {
        //if the bullet hits a target
        if(touched == false)
        {
            if (other.tag.Equals("Player"))
            {
                Debug.Log("I touched the key");
                mainInventory.GetComponent<Inventory>().UpdateGoldKeys(1);
                keyInvetory.GetComponent<Text>().text = "x" + mainInventory.GetComponent<Inventory>().numGoldKeys;
                touched = true;


            }
        }
      


    }


    private void FixedUpdate()
    {
        if (touched == true)
        {
            keyFalling -= 0.1;
            transform.position = playerOne.transform.position + new Vector3(0, (float)keyFalling, 0);
            transform.localScale += scaleChange;
        }

        if(keyFalling <= 0)
        {
            Debug.Log("key is dead");
            Destroy(gameObject);
        }

        if(touched == false)
        {
            transform.position += new Vector3(0, (float)(Math.Sin(Time.time) *.005), 0);
        }
        
    }


}
