using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gate : MonoBehaviour
{
    public GameObject gateText;
    GameObject player;
    public GameObject gate;
    public Renderer rend;
    public Alien alien;
    public AlienInfoCanvas aic;
    private GameObject mainInventory;
    private bool gateMoving;
    private MeshRenderer gateColor;
    private bool gateCollision;
    private GameObject keyInvetory;
    void Start()
    {
        //gateText = GameObject.FindWithTag("GateText");
        player = GameObject.FindWithTag("Player");
        //gate = GameObject.FindWithTag("Gate");
        mainInventory = GameObject.FindWithTag("Inventory");
        keyInvetory = GameObject.FindWithTag("Gold Key Updater");
        rend = gateText.GetComponent<Renderer>();
        gateColor = gate.GetComponent<MeshRenderer>();
        rend.enabled = false;
        gateMoving = false;
        gateCollision = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if(mainInventory.GetComponent<Inventory>().numGoldKeys <= 0)
            {
                gateText.GetComponent<TextMeshPro>().text = "You do not have enough Gold Keys!";
            }
            else
            {
                gateText.GetComponent<TextMeshPro>().text = "Press E to get Alien";
            }
            Debug.Log("I collided with the gate");
            rend.enabled = true;
            gateCollision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("I UNcollided with the gate");
            rend.enabled = false;
            gateCollision = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && gateMoving == false && gateCollision == true && mainInventory.GetComponent<Inventory>().numGoldKeys > 0)
        {
            gateMoving = true;
            rend.enabled = false;
            mainInventory.GetComponent<Inventory>().numGoldKeys -= 1;
            keyInvetory.GetComponent<Text>().text = "x" + mainInventory.GetComponent<Inventory>().numGoldKeys;
            //alien.PickUp();
            aic.Enable();
        }

        if (gateMoving == true)
        {
            
            gateColor.material.color += new Color(0,0,0,-(float)0.01);
            //Debug.Log(gateColor.material.color.ToString());
            transform.position = transform.position + new Vector3(0, (float)0.015, 0);
        }

        if(gateColor.material.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
