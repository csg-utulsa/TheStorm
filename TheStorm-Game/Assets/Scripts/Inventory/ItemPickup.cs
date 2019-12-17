using UnityEngine;
using TMPro;
/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: defines interactable items*/
public class ItemPickup : Pickup
{//inherents from Interactble class

    /****VARIABLES****/
    public Item item; //get item properites

    protected override void PickUp()
    {
        Debug.Log("picked up " + item.name); //test pick

        bool wasPickedUp = Inventory.instance.Add(item); //add item and return if true or false

        if (wasPickedUp)
        {
         Destroy(gameObject); //destory item object;
        }
    }//
}//class
