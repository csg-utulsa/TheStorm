using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject player;
    public GameObject FOV_p;
    public GameObject FOV;
    public GameObject agroCircle;
    public Slider healthBar;
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

        // DEBUG TO TEST DAMAGE FUNCTION //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(5);
        }

        // PASSIVE & FOLLOWING WAYPOINTS //
        if (!alerted && waypoints != null)
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                // distance between waypoint and enemy
                Vector3 distance = waypoints[waypointIndex].position - FOV_p.transform.position;
                
                // calculate rotation between field of vision and the waypoint position
                Quaternion rot = Quaternion.Slerp(FOV_p.transform.rotation, Quaternion.LookRotation(distance), speed * Time.deltaTime);
                
                // rotate the field of vision
                FOV_p.transform.rotation = rot;

                // move towards the waypoint
                transform.position = Vector3.MoveTowards(transform.position, 
                    waypoints[waypointIndex].transform.position,
                    speed * Time.deltaTime);

                // goto next waypoint or loop movement around waypoints upon reaching the last one
                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            } else
            {
                waypointIndex = 0;
            }
        }

        // AGGRO //
        if (alerted)
        { 
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEntered");
        if (collision.transform.gameObject.tag == "Player" || collision.transform.gameObject.tag == "Enemy")
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

    public void takeDamage(int damage)
    {
        healthBar.value -= damage;
        if (healthBar.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
