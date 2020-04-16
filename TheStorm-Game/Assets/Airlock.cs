using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airlock : MonoBehaviour
{
    public GameObject affectedDoor;
    public bool locked;

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log("Test2");
        if (!locked && c.gameObject.CompareTag("Player"))
        {
            Debug.Log("Test1");
            affectedDoor.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            affectedDoor.SetActive(true);
        }
    }
}
