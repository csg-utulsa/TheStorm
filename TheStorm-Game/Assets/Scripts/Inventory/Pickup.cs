using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickup : Interactable
{
    public TextMeshProUGUI textPrompt;

    // public void Awake()
    // {
    //     var playerObjects = GameObject.FindGameObjectsWithTag("Player");
    //
    //     foreach(GameObject o in playerObjects)
    //     {
    //         if(o.GetComponent<Player>() != null)
    //         {
    //             player = o;
    //             return;
    //         }
    //     }
    // }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        float distance = Vector3.Distance(player.transform.position, interactionTransform.position);
        if ((distance <= radius))
        {
            textPrompt.gameObject.SetActive(true);
        }
        else
        {
            textPrompt.gameObject.SetActive(false);
        }
    }

    public override void Interact()
    {
        base.Interact();//run the parent method

        PickUp();
    }

    protected virtual void PickUp()
    {

    }
}
