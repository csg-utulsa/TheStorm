using UnityEngine;

/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: Creates asset menu item and properites*/

[CreateAssetMenu (fileName = "New Item", menuName = "Inventory/Item")]
//menu item for object
public class Item : ScriptableObject
{//scritable object : custom asset with properties

    /****VARIABLES****/

    new public string name = "new Item"; //new prefix overides Unity name property
    public Sprite icon = null; //icon for item
    public bool isDefaultItem = false; //if the item is a defualt equiped item

    public virtual void Use()
    {
        //what the item does

        Debug.Log("Using " + name);
    }


}
