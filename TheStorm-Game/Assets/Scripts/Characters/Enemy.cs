using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject FOV;
    public Material m_yellow;
    public Material m_red;
    public float speed;
    public bool alerted = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (alerted)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OntriggerEntered");
        if (other.tag == "Player")
        {
            print("guard triggered");
            alerted = true;
            FOV.GetComponent<Renderer>().material = m_red;
        }
    }
}
