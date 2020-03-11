using System;
using UnityEngine;
/*Author: Akram Taghavi-Burris
 * Created: 10-20-19
 * Modified: 10-20-19
 * Description: defines interactables*/
public class Interactable : MonoBehaviour
{
    /****VARIABLES****/
    public float radius = 3f; //how close to interact
    public Transform interactionTransform; //tranform of Interactable (does not have to be the object, but an empty object defines the exact location of where the inateraction takes place)
    public bool isFocused = false; //is interactable selected
    public GameObject player; //the player
    public Player playerScript;
    public bool hasInteracted = false;//check if interacted with
    private bool informed = false;

    private Vector3 startPosition = Vector3.zero;

    void Start()
    {

        //playerScript = player.GetComponentInChildren<Player>();
        playerScript.PrintTest();

    }

    public virtual void Interact()
    {//virtual methods are parent methods that are called and can be added to
        Debug.Log("Interact");
    }

    public void Update()
    {
        if(startPosition == Vector3.zero)
        {
            startPosition = transform.position;
            print(transform.position);
        }
        transform.position = startPosition + new Vector3(0, .2f*Mathf.Sin(Time.time), 0.0f);

        float distance = Vector3.Distance(player.transform.position, interactionTransform.position);

        if (isFocused && !hasInteracted)
        {//if focused and has not yet interacted

            //get distance to player
            //float distance = Vector3.Distance(player.position, interactionTransform.position);
               
                if(distance <= radius)
            {//if distnace is within radius
                Interact();
                hasInteracted = true;
            }
        }

        //if ((distance <= radius) && Input.GetKeyDown(KeyCode.E))
        //{//if distnace is within radius
        //    Interact();
        //    hasInteracted = true;
        //}

        if (distance <= radius)
        {

            playerScript.InformInteractableClose(distance, this);
            informed = true;

        }
        else
        {

            if (informed)
                playerScript.InformInteractableNotClose(this);

        }
    }


    public void OnFocused(Transform playerTranform)
    {
        isFocused = true; //set focus
        player = playerTranform.gameObject; //set the player
        hasInteracted = false; //rest interaction when focused
    }//end OnFocused

    public void OnDeFocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false; //rest interaction when defocused
    }//end OnDeFocused

    private void OnDrawGizmosSelected()
    { //gizmo to display object

        if(interactionTransform == null)
        {//if we have no interaction Transform, set the transform to the interatable own transform
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

}//end class
