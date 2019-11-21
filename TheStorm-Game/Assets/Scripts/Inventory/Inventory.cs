using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: defines the singelton of inventory*/


public class Inventory : MonoBehaviour
{//there can only ever be one instance of this class, thus we start by defeining the singleton

    #region Singleton
    //regions are blocks of code that are grouped together for condensing in the editor. 

    public static Inventory instance; //static variable (creating a singalton)
    private void Awake()
    {
        if (instance != null)
        {//display waring if more than one inventory instance exsists
            Debug.LogWarning("More than one instance of Invenotry found!");
        }

        instance = this; //set this as the insance
    }
    #endregion

    /****VARIABLES****/

    public List<Item> items = new List<Item>(); //list of items in inventory
    public int space = 20; //item space amount in inventory

    //The delegate is used to update the inventory UI when adding and removing items
    public delegate void OnItemChanged(); //delegates are variables that reference a method
    public OnItemChanged onItemChangedCallback; //the delegate method is set to a varialbe


    //Add item to list
    public bool Add(Item item)
    {//returns a boolean if we did or did not add the item

        if (!item.isDefaultItem)
        {//only add none default items to inventory

            if(items.Count >= space)
            {//if there is not room in inventory , return
                Debug.Log("Not enough room");
                return false;
            }

          //otherwise add item  
          items.Add(item);

        if(onItemChangedCallback != null)
            {//if method is not null, invoke the method
                onItemChangedCallback.Invoke();
            }
            

        }

        return true;
    }//end Add

    //Remove item from list
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {//if method is not null, invoke the method
            onItemChangedCallback.Invoke();
            Debug.Log("removed");
        }

    }//end Remove

}//end class
