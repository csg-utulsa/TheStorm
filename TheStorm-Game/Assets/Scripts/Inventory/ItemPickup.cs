using UnityEngine;
using TMPro;
/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: defines interactable items*/
public class ItemPickup : Interactable
{//inherents from Interactble class

    /****VARIABLES****/
    public Item item; //get item properites
    public TextMeshPro textPrompt;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Interact()
    {
        base.Interact();//run the parent method

        PickUp();

    }//end Interact

    public new void Update()
    {
        base.Update();

        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if ((distance <= radius))
        {
            textPrompt.gameObject.SetActive(true);
        }
        else
        {
            textPrompt.gameObject.SetActive(false);
        }
    }


    void PickUp()
    {
        Debug.Log("picked up " + item.name); //test pick

        bool wasPickedUp = Inventory.instance.Add(item); //add item and return if true or false

        if (wasPickedUp)
        {
         Destroy(gameObject); //destory item object;
        }
       

    }//

}//class
