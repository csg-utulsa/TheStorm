using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScoreText : MonoBehaviour
{

    private GameObject mainInventory;
    
    private int numGoldKey;
    
    void Start()
    {
        mainInventory = GameObject.FindWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (mainInventory.GetComponent<Inventory>().numGoldKeys == numGoldKey)
        {
            numGoldKey = mainInventory.GetComponent<Inventory>().numGoldKeys;
            GetComponent<Text>().text = "x" + numGoldKey;
        }
    }
}
