using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInfoCanvas : MonoBehaviour
{
    public Alien alien;

    public GameObject ReplaceAlien1Button;
    public GameObject ReplaceAlien2Button;

    public void Enable()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void TakeAlien()
    {
        if (Inventory.instance.currentAlienIndex == Inventory.instance.maxAlienIndex)
        {
            gameObject.transform.GetChild(0).transform.Find("Take Button").gameObject.SetActive(false);
            gameObject.transform.GetChild(0).transform.Find("Release Button").gameObject.SetActive(false);
            gameObject.transform.GetChild(0).transform.Find("ReplaceAlien1Button").gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.Find("ReplaceAlien2Button").gameObject.SetActive(true);
            gameObject.transform.GetChild(0).transform.Find("CancelReplaceButton").gameObject.SetActive(true);
        }
        else
        {
            alien.PickUp();
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ReleaseAlien()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        alien.Release();
    }

    public void SwapAlien(int index)
    {
        gameObject.transform.GetChild(0).transform.Find("Take Button").gameObject.SetActive(true);
        gameObject.transform.GetChild(0).transform.Find("Release Button").gameObject.SetActive(true);
        gameObject.transform.GetChild(0).transform.Find("ReplaceAlien1Button").gameObject.SetActive(false);
        gameObject.transform.GetChild(0).transform.Find("ReplaceAlien2Button").gameObject.SetActive(false);
        gameObject.transform.GetChild(0).transform.Find("CancelReplaceButton").gameObject.SetActive(false);

        Inventory.instance.alienSlots[index].RemoveBuff();
        Inventory.instance.alienSlots[index] = alien.buff;
        Inventory.instance.alienSlots[index].ApplyBuff();
        Inventory.instance.alienSlotsImage[index].sprite = alien.sprite;

        ReleaseAlien();

        //this.gameObject.SetActive(false);
        //Time.timeScale = 1;
    }

    public void CancelSwap()
    {
        gameObject.transform.GetChild(0).transform.Find("Take Button").gameObject.SetActive(true);
        gameObject.transform.GetChild(0).transform.Find("Release Button").gameObject.SetActive(true);
        gameObject.transform.GetChild(0).transform.Find("ReplaceAlien1Button").gameObject.SetActive(false);
        gameObject.transform.GetChild(0).transform.Find("ReplaceAlien2Button").gameObject.SetActive(false);
        gameObject.transform.GetChild(0).transform.Find("CancelReplaceButton").gameObject.SetActive(false);

        ReleaseAlien();
    }
}
