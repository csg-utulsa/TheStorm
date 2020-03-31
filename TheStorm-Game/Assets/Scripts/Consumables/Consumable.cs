using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    AudioSource audioData;
    public Sprite itemImage;
    public static List<List<Consumable>> consumables = new List<List<Consumable>>(); //list of consumables the player holds
    public static List<Consumable> selectedConsumable = null; //contains the number of items of the currently selected consumable
    public static short selectedConsumableIndex = 0; //index of selectedConsumable in consumables list

    private ConsumableSlot slot;
    private static bool usePressed = false;
    private static bool upPressed = false;
    private static bool downPressed = false;


    void Start()
    {
        audioData = GetComponent<AudioSource>();
        slot = GameObject.Find("ConsumablesSlot").GetComponent<ConsumableSlot>(); //get a reference to the consumables inventory slot
    }

    void Update()
    {
        // //use the item
        // if (selectedConsumable != null && Input.GetKeyDown(KeyCode.F))
        // {
        //     if (selectedConsumable[0].Equals(this) && !usePressed)
        //     {
        //         usePressed = true;
        //         selectedConsumable[0].useItem();
        //     }
        // }
        //
        //
        // //reset input after a key is raised
        // if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        // {
        //     usePressed = false;
        //     upPressed = false;
        //     downPressed = false;
        // }
        //
        // //cycle down consumables in inventory, loop when index is below 0
        // if(selectedConsumable != null && Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     if (selectedConsumable[0].Equals(this) && !downPressed)
        //     {
        //         downPressed = true;
        //
        //         selectedConsumableIndex--;
        //
        //         if (selectedConsumableIndex < 0)
        //         {
        //             selectedConsumableIndex = (short)(consumables.Count-1);
        //         }
        //
        //         selectedConsumable = consumables[selectedConsumableIndex];
        //         slot.setImage(selectedConsumable[0].itemImage, (short)(selectedConsumable.Count));
        //     }
        // }
        //
        // //cycle up consumables in inventory, loop when index is above size of consumables list
        // if (selectedConsumable != null && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     if (selectedConsumable[0].Equals(this) && !upPressed)
        //     {
        //         upPressed = true;
        //
        //         selectedConsumableIndex++;
        //
        //         if(selectedConsumableIndex > consumables.Count - 1)
        //         {
        //             selectedConsumableIndex = 0;
        //         }
        //
        //         selectedConsumable = consumables[selectedConsumableIndex];
        //         slot.setImage(selectedConsumable[0].itemImage, (short)(selectedConsumable.Count));
        //     }
        // }
    }

    public void ChangeConsumableForward()
    {

        selectedConsumableIndex++;

        if (selectedConsumableIndex > consumables.Count - 1)
        {
            selectedConsumableIndex = 0;
        }

        selectedConsumable = consumables[selectedConsumableIndex];
        slot.setImage(selectedConsumable[0].itemImage, (short)(selectedConsumable.Count));

    }

    public void ChangeConsumableBackward()
    {
        
        selectedConsumableIndex--;
        
        if (selectedConsumableIndex < 0)
        {
            selectedConsumableIndex = (short)(consumables.Count-1);
        }
        
        selectedConsumable = consumables[selectedConsumableIndex];
        slot.setImage(selectedConsumable[0].itemImage, (short)(selectedConsumable.Count));
        
    }

    //After consumable is used, remove it from the inventory
    public virtual void useItem()
    {
        //if the consumable that was selected is now empty, we need to set the selected consumable to a new value
        if (selectedConsumable.Count == 0)
        {
            consumables.Remove(selectedConsumable);

            //if the list is empty, set values to null
            if (consumables.Count == 0)
            {
                selectedConsumableIndex = 0;
                selectedConsumable = null;
                slot.setImage(null, 0);
            }
            else
            {
                //if the selected consumable is not 0, we can simply set the active consumable to the previous one in the list
                if (selectedConsumableIndex != 0)
                {
                    selectedConsumableIndex -= 1;
                    selectedConsumable = consumables[selectedConsumableIndex];
                    slot.setImage(selectedConsumable[0].itemImage, (short)selectedConsumable.Count);
                }
                //if the selected consumable is 0, we can set the selected consumable to the new smallest value in the consumable list
                else
                {
                    selectedConsumable = consumables[selectedConsumableIndex];
                    slot.setImage(selectedConsumable[0].itemImage, (short)selectedConsumable.Count);
                }
            }
        }
        //If the list is not empty then we simply set the counter for this consumable to one less than before
        else
        {
            slot.setImage(selectedConsumable[0].itemImage, (short)selectedConsumable.Count);
        }
    }

    //Add an item to the consumables list
    public void addItem() {
        bool itemAdded = false;//used to check if a new consumable needs to be added to the consumables list
        for (int i = 0; i < consumables.Count; i++)
        {
            List<Consumable> thisList = consumables[i];
            //Loop through types of consumables
            if (thisList[0].GetType().Equals(this.GetType()))
            {
                thisList.Add(this); //add this pickup to the list of the proper consumable
                itemAdded = true;
                slot.setImage(selectedConsumable[0].itemImage, (short)selectedConsumable.Count);//set UI slot
                break;
            }
        }
        //If the item was not added to a list, we need a new list for this consumable
        if (!itemAdded)
        {
            consumables.Add(new List<Consumable>()); //add a list to hold this type of consumable
            consumables[consumables.Count-1].Add(this); //add a new consumable to this list
            
            //if this is the first item in the list, set it as the active consumable
            if (consumables.Count == 1)
            {
                selectedConsumable = consumables[consumables.Count - 1];
                slot.setImage(this.itemImage, (short)(selectedConsumable.Count));
            }
        }
    }

    //when the player picks up the item, add it to the inventory, play the pickup sound, and remove it from the level
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            addItem();

            audioData.Play(0);

            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }
}
