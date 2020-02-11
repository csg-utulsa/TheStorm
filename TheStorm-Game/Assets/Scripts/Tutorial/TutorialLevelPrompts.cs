using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLevelPrompts : MonoBehaviour
{
    public GameObject movePrompt;
    public GameObject pickupPrompt;
    public GameObject firePrompt;
    public GameObject swapPrompt;
    public GameObject useConsumablePrompt;
    public GameObject swapConsumablePrompt;

    private bool movePromptFinished = false;
    private float pickupPromptTimer=0;
    private float swapConsumablePromptTimer = 0;
    private bool firePromptFinished = false;
    private bool swapPromptFinished = false;
    private bool useConsumablePromptFinished = false;

    void Start()
    {
        movePrompt.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.D))
        {
            movePrompt.SetActive(false);
            movePromptFinished = true;
        }
        if (movePromptFinished)
        {
            pickupPrompt.SetActive(true);
            if(pickupPromptTimer==0)
                pickupPromptTimer = Time.time+5;
        }
        if (pickupPrompt.active && (pickupPromptTimer < Time.time))
        {
            pickupPrompt.SetActive(false);
        }
        if (!firePromptFinished && GameObject.Find("PlayerChild").GetComponent<Player>().equippedWeapon != null)
        {
            pickupPrompt.SetActive(false);
            useConsumablePrompt.SetActive(false);
            //useConsumablePromptFinished = true;
            firePrompt.SetActive(true);
        }
        if (firePrompt.active && Input.GetMouseButton(0))
        {
            firePrompt.SetActive(false);
            firePromptFinished = true;
        }
        if (!swapPromptFinished && GameObject.Find("PlayerChild").GetComponent<Player>().secondaryWeapon != null)
        {
            pickupPrompt.SetActive(false);
            firePrompt.SetActive(false);
            //firePromptFinished = true;
            swapPrompt.SetActive(true);
        }
        if (swapPrompt.active && Input.GetKeyDown(KeyCode.Q))
        {
            swapPrompt.SetActive(false);
            swapPromptFinished = true;
        }
        if (!useConsumablePromptFinished && GameObject.Find("ConsumablesSlot").GetComponent<ConsumableSlot>().gameObject.transform.GetChild(0).GetComponent<Image>().sprite != null)
        {
            pickupPrompt.SetActive(false);
            firePrompt.SetActive(false);
            //firePromptFinished = true;
            swapPrompt.SetActive(false);
            //swapPromptFinished = true;
            useConsumablePrompt.SetActive(true);
        }
        if(useConsumablePrompt.active && Input.GetKeyDown(KeyCode.F))
        {
            useConsumablePrompt.SetActive(false);
            useConsumablePromptFinished = true;
        }
        if (useConsumablePromptFinished)
        {
            swapConsumablePrompt.SetActive(true);
            if (swapConsumablePromptTimer == 0)
                swapConsumablePromptTimer = Time.time + 5;
        }
        if (swapConsumablePrompt.active && (swapConsumablePromptTimer < Time.time))
        {
            swapConsumablePrompt.SetActive(false);
        }
    }
}
