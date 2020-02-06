using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableSlot : MonoBehaviour
{
    public void setImage(Sprite image, short count)
    {
        //print(gameObject.transform.GetChild(1).GetComponent<Text>().text);

        gameObject.transform.GetChild(1).gameObject.SetActive(true);

        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = image;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = count+"";

        if(count == 0)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
