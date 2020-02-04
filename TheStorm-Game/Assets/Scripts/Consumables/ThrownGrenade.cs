using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownGrenade : MonoBehaviour
{
    public int timer = 5;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime+timer < Time.time)
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 1);
            int i = 0;
            while (i < hitColliders.Length)
            {
                //hitColliders[i].SendMessage("AddDamage");
                if (hitColliders[i].gameObject.tag == "Player")
                {
                    hitColliders[i].gameObject.GetComponentInChildren<Player>().TakeDamage(1);
                }
                i++;
            }

            Destroy(gameObject);
        }
    }
}
