using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // GAME OBJECTS //
    [Header("GameObjects")]
    public GameObject player;
    public GameObject pivot;
    public GameObject FOV;
    public GameObject aggroCircle;
    public Slider healthBar;

    // MATERIALS //
    [Header("Materials")]
    public Material m_yellow;
    public Material m_red;

    // VARIABLES
    [Header("Variables")]
    public float speed;
    public bool alerted = false;

    // AI PATHING //
    [Header("Pathing")]
    public NavMeshAgent agent;
    public Transform[] waypoints;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // find the player
        player = GameObject.FindGameObjectWithTag("Player");

        // get the attached navmeshagent component
        agent = GetComponent<NavMeshAgent>();

        // prevent the gameobject from rotating by means of the agent
        agent.updateRotation = false;

        // if there are waypoints
        if (waypoints.Length > 0)
        {
            // set the destination to walk towards
            agent.SetDestination(waypoints[waypointIndex].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // DEBUG TO TEST DAMAGE FUNCTION //
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    takeDamage(5);
        //}

        // PASSIVE & FOLLOWING WAYPOINTS //
        if (!alerted && waypoints != null)
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                // distance between waypoint and enemy
                Vector3 distance = waypoints[waypointIndex].position - pivot.transform.position;

                // calculate rotation between field of vision and the waypoint position
                Quaternion rot = Quaternion.Slerp(pivot.transform.rotation, Quaternion.LookRotation(distance), speed * Time.deltaTime);

                // rotate the field of vision
                rot.x = 0;
                rot.z = 0;
                pivot.transform.rotation = rot;

                // set the new destination to walk towards
                agent.SetDestination(waypoints[waypointIndex].transform.position);

                // if the agent's x and z match the x and z of the waypoint
                if (agent.transform.position.x == waypoints[waypointIndex].transform.position.x &&
                    agent.transform.position.z == waypoints[waypointIndex].transform.position.z)
                {
                    // debug for when the player reached the waypoint
                    print("Waypoint reached");

                    // increment the waypoint index
                    waypointIndex += 1;
                }
            }
            else
            {
                // reset the pathing to the origin
                waypointIndex = 0;
            }
        }

        // AGGRO //
        if (alerted)
        {
            // update the agent's destination as the position of the player
            agent.SetDestination(player.transform.position);
        }
    }

    // HITBOX COLLISION //
    private void OnCollisionEnter(Collision collision)
    {
        // print the function call
        print("OnCollisionEnter(" + collision.gameObject + ")");

        // if collided with by either a player or other enemy
        if (collision.transform.gameObject.tag == "Player" || collision.transform.gameObject.tag == "Enemy")
        {
            // function call
            becomeAlerted();
        }
    }

    // ALERT //
    public void becomeAlerted()
    {
        // print the function call
        print("becomeAlerted()");

        // set status to alerted
        alerted = true;

        // disable field of vision
        FOV.SetActive(false);

        // set active the aggro circle
        aggroCircle.SetActive(true);
    }

    // TAKE DAMAGE //
    public void takeDamage(int damage)
    {
        // print the function call
        print("takeDamage(" + damage + ")");

        // reduce the health bar value by the damage amount
        healthBar.value -= damage;

        // if the health has reached 0
        if (healthBar.value <= 0)
        {
            // destroy the game object
            Destroy(gameObject);
        }
    }
}