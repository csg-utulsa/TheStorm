using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertEnemy : MonoBehaviour
{
    public GameObject parent;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Transform>().parent.gameObject.GetComponentInParent<Enemy>();
        //enemy = parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            enemy.BecomeAlerted();
        }
    }
}
