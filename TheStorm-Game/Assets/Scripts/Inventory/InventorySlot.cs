
using UnityEngine;
using UnityEngine.UI;

/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: records what is in the item slot */



public class InventorySlot : MonoBehaviour
{

    /***Variable***/

    public Image icon;
    public Button removeButton;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem; //set the new item
        icon.sprite = item.icon; //grab the item property
        icon.enabled = true; //enable the image
        //removeButton.interactable = true; //activate remove button 
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }


    public void OnRemoveButton()
    {//when the remove button is pressed
        Debug.Log("remove item");
        Inventory.instance.Remove(item);
        
       
    }

    public void UseItem()
    {//use the item

        if(item != null)
        {//check if there is an item
            item.Use(); //use item
        }
    }




}//end class
