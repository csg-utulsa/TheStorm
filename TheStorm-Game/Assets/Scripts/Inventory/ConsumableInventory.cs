using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{

    public int[] itemList = new int[5];
    public Sprite[] spriteList = new Sprite[5];

    public int itemIndex = 0;
    
    private GameObject item;

    public Text text1, text2, text3;
    public Sprite sprite1, sprite2, sprite3;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // CHANGE ITEM BACKWARDS
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DecreaseIndex();
        }

        // CHANGE ITEM FORWARDS
        if (Input.GetKeyDown(KeyCode.E))
        {
            IncreaseIndex();
        }

        // USE ITEM
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (itemList[itemIndex] > 0)
            {
                UseItem();
            }
            
        }
    }

    void LateUpdate()
    {
        // UPDATE PREVIOUS ITEM
        int previousIndex = itemIndex - 1;

        if (previousIndex < 0)
        {
            previousIndex = 4;
        }
        text1.text = itemList[previousIndex].ToString();
        sprite1 = spriteList[previousIndex];

        // UPDATE CURRENT ITEM
        text2.text = itemList[itemIndex].ToString();
        sprite2 = spriteList[itemIndex];

        // UPDATE NEXT ITEM
        int nextIndex = itemIndex + 1;

        if (nextIndex >= 5)
        {
            nextIndex = 0;
        }
        text3.text = itemList[nextIndex].ToString();
        sprite3 = spriteList[nextIndex];
    }

    // USING AN ITEM
    public void UseItem(GameObject item)
    {
        Instantiate(item);
        DecreaseItemCount(itemIndex);
    }

    void UseItem()
    {
        Instantiate(item);
        DecreaseItemCount(itemIndex);
    }

    // PICKUP AN ITEM
    public void PickupItem(GameObject item)
    {
        Destroy(item);
        IncreaseItemCount(itemIndex);
    }

    // INCREASE THE ITEM COUNT
    void IncreaseItemCount(int index)
    {
        int value = itemList[index];
        value++;
        itemList[index] = value;
    }
    
    // DECREASE THE ITEM COUNT
    void DecreaseItemCount(int index)
    {
        int value = itemList[index];
        if (value > 0)
        {
            value--;
        }
        itemList[index] = value;
    }

    // DECREASE THE INDEX
    void DecreaseIndex()
    {
        itemIndex--;

        if (itemIndex < 0)
        {
            itemIndex = 4;
        }
    }

    // INCREASE THE INDEX
    void IncreaseIndex()
    {
        itemIndex++;

        if (itemIndex >= 5)
        {
            itemIndex = 0;
        }
    }
}
