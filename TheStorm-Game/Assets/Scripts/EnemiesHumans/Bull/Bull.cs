using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Handles the Bull Guard
/// </summary>
public class Bull : Character
{

    // GAME OBJECTS //
    [Header("GameObjects")]
    public GameObject player;
    public GameObject pivot;
    public GameObject FOV;
    public GameObject FOVCone;
    public GameObject aggroCircle;
    public Slider enemyHealthBar;

    // MATERIALS //
    [Header("Materials")]
    public Material m_yellow;
    public Material m_red;

    // VARIABLES
    [Header("Variables")]
    public bool alerted = false;
    public bool charging = false;
    public int waitTime = 2;
    public int damage = 5;
    public int force = 10;
    public float speedBoost = 2;

    // AI PATHING //
    [Header("Pathing")]
    public Transform[] waypoints;
    private int waypointIndex = 0;
    Vector3 chargeDestination;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        // find the player
        player = GameObject.FindGameObjectWithTag("Player");

        // prevent the gameobject from rotating by means of the agent
        agent.updateRotation = false;

        agent.speed = speed;

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
        // function to move
        Move();
    }


    protected override void Move()
    {
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

            // if taken damage
            if (healthBar.value < healthBar.maxValue)
            {
                BecomeAlerted();
            }
        }

        // AGGRO //
        if (alerted && player != null)
        {
            AlertAction();
        }
    }

    // HITBOX COLLISION //
    private void OnCollisionEnter(Collision collision)
    {
        // print the function call
        print("Bull has collided with " + collision.gameObject);
        
        // if collided with by either a player or other enemy
        if (!alerted && collision.transform.gameObject.tag == "Player" || collision.transform.gameObject.tag == "Enemy" || collision.transform.gameObject.tag == "Bullet")
        {
            if (collision.transform.gameObject.tag == "Enemy")
            {
                Enemy other = collision.transform.GetComponent<Enemy>();
                if (other.alerted == false)
                {
                    return;
                }
            }
            // Bull specific contact with the player
            /*else if (collision.transform.gameObject.tag == "Player")
            {
                player.GetComponent<Character>().TakeDamage(damage);
                KnockBack(gameObject, force);

            }*/ 
            else 
            {
                // function call
                BecomeAlerted();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alerted && other.transform.gameObject.tag == "Bullet")
        {
            // function call
            BecomeAlerted();
        }
    }

    // ALERT //
    public void BecomeAlerted()
    {
        // print the function call
        print("becomeAlerted()");

        // set status to alerted
        alerted = true;

        // disable field of vision
        FOV.SetActive(false);
        FOVCone.SetActive(false);

        // set active the aggro circle
        aggroCircle.SetActive(true);

        // start attacking player
        StartAttack();
    }

    public void AlertAction()
    {
        // update the agent's destination as the position of the player
        transform.LookAt(player.transform);
        Charge();
    }

    public void Charge()
    {
        if (!charging)
        {
            StartCoroutine(Charging()); 
        }
    }

    IEnumerator Charging()
    {
        charging = true;
        agent.isStopped = true;
        Debug.Log("Bull is preparing to charge");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Charging!");

        agent.speed *= speedBoost;
        chargeDestination = player.transform.position + transform.forward * 2;
        agent.isStopped = false;
        agent.SetDestination(chargeDestination);
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        Debug.Log("Bull is cooling down");
        yield return new WaitForSeconds(waitTime + 1);
        Debug.Log("Bull is ready to go again");
        charging = false;
    }

    public void KnockBack(GameObject bull, int force)
    {
        Vector3 knock = bull.transform.forward;
        knock *= force;
        player.GetComponent<Rigidbody>().AddForce(knock);
    }
}
