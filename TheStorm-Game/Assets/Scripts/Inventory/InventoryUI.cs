using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: controls the UI of the inventory*/

public class InventoryUI : MonoBehaviour
{

    /***Variable***/
    Inventory inventory; //reference to the inventory
    InventorySlot[] slots; //array for each slot

    public Transform itemGrid; //parent item holding all item slots
    public GameObject inventoryUI; //the inventory object

    private void Start()
    {
        inventory = Inventory.instance; //set the inventory
        inventory.onItemChangedCallback += UpdateUI; //adds what method to call when invoked

        slots = itemGrid.GetComponentsInChildren<InventorySlot>(); //add the Inventory slot component of all childeren objects in the itemGrid to the slots array
    }



    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {//if inventory button pressed (see project setting inputs)
            inventoryUI.SetActive(!inventoryUI.activeSelf);//set the inverse of the active state
        }
    }



    void UpdateUI()
    {//update the UI 

        Debug.Log("update ui");

        //loop through all slots
        for(int i=0; i<slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {//if there is more items to count
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }


}
