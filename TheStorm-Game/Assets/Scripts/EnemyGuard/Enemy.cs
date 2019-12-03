using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public GameObject FOV;
    public GameObject agroCircle;
    [Header("Materials")]
    public Material m_yellow;
    public Material m_red;
    [Header("Variables")]
    public float speed;
    public bool alerted = false;
    [Header("Pathing")]
    public Transform[] waypoints;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!alerted && waypoints != null)
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                transform.LookAt(waypoints[waypointIndex].transform.position);

                transform.position = Vector3.MoveTowards(transform.position, 
                    waypoints[waypointIndex].transform.position,
                    speed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            } else
            {
                waypointIndex = 0;
            }
        }

        if (alerted)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OntriggerEntered");
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            becomeAlerted();
        }
    }

    public void becomeAlerted()
    {
        print("guard triggered");
        alerted = true;
        FOV.SetActive(false);
        agroCircle.SetActive(true);
    }

}
