using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public InventorySlot[] slots;
    public Image[] weaponSlots;
    public Image[] alienSlots;

    private int currentAlienIndex;
    private int maxAlienIndex;

    public Text scoreText;
    private int score;
    public int numGoldKeys;
    public int numSilverKeys;

    public GameController gc;

    private bool itemsVisible = true;

    public void Start()
    {
        onItemChangedCallback += UpdateUI;
        ToggleItemInventory();

        currentAlienIndex = 0;
        maxAlienIndex = alienSlots.Length;
        foreach (Image image in alienSlots)
            image.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleItemInventory();
        }
    }

    //Add item to list
    public bool Add(Item item)
    {//returns a boolean if we did or did not add the item

        if (!item.isDefaultItem)
        {//only add none default items to inventory

            if (items.Count >= space)
            {//if there is not room in inventory , return
                Debug.Log("Not enough room" + items.Count);
                return false;
            }

            //otherwise add item  
            items.Add(item);

            if (onItemChangedCallback != null)
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

    void UpdateUI()
    {//update the UI 

        Debug.Log("update ui");

        //loop through all slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {//if there is more items to count
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    public void SetWeaponSlots(Sprite weapon1, Sprite weapon2)
    {
        if (weapon1 != null)
        {
            weaponSlots[0].sprite = weapon1;
        }

        if (weapon2 != null)
        {
            weaponSlots[1].sprite = weapon2;
        }
    }

    public void ClearWeaponSlots(bool weapon1, bool weapon2)
    {
        if(weapon1)
        {
            weaponSlots[0].sprite = null;
        }

        if (weapon2)
        {
            weaponSlots[1].sprite = null;
        }
    }

    /// <summary>
    /// Adds an Alien to the Inventory
    /// </summary>
    /// <param name="alien">The sprite to display.</param>
    public void AddAlien(Sprite alien)
    {

        if (currentAlienIndex == maxAlienIndex)
        {

            Debug.Log("Can't add another alien...");
            return;

        }
        else
        {
            Debug.Log("Adding Alien");
            alienSlots[currentAlienIndex].sprite = alien;
            alienSlots[currentAlienIndex++].enabled = true;
        }

    }

    private void ToggleItemInventory()
    {
        itemsVisible = !itemsVisible;

        foreach (InventorySlot iS in slots)
        {
            iS.SetVisible(itemsVisible);
        }
    }

    public void UpdateScore(int num)
    {
        score += num;
        scoreText.text = "Score: " + score;
        if (score == 120) {
            gc.Win();
        }
    }

    public void UpdateGoldKeys(int key)
    {
        numGoldKeys += key;
    }

}//end class