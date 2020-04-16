using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    public GameObject enemies;
    public Airlock door;

    private void Start()
    {
        enemies.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            enemies.SetActive(true);
            door.locked = true;
        }
    }
}
