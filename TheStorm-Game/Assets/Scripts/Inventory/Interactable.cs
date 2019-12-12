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
    public Transform player; //the player
    public bool hasInteracted = false;//check if interacted with
    

    public virtual void Interact()
    {//virtual methods are parent methods that are called and can be added to
        Debug.Log("Interact");
    }

    public void Update()
    {
        float distance = Vector3.Distance(player.position, interactionTransform.position);

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

        if ((distance <= radius) && Input.GetKeyDown(KeyCode.E))
        {//if distnace is within radius
            Interact();
            hasInteracted = true;
        }
    }

    public void OnFocused(Transform playerTranform)
    {
        isFocused = true; //set focus
        player = playerTranform; //set the player
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
