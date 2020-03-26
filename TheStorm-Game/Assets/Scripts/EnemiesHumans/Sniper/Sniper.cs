using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Sniper : Character
{
    // GAME OBJECTS //
    [Header("GameObjects")]
    public GameObject player;
    public GameObject pivot;
    public GameObject FOV;
    public GameObject FOVCone;
    public GameObject aggroCircle;
    public Slider enemyHealthBar;
    public LineRenderer sniperLine;

    // MATERIALS //
    [Header("Materials")]
    public Material m_yellow;
    public Material m_red;

    // VARIABLES
    [Header("Variables")]
    public bool alerted = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        // find the player
        player = GameObject.FindGameObjectWithTag("Player");

        // get sniper line
        sniperLine = GetComponent<LineRenderer>();

        // prevent the gameobject from rotating by means of the agent
        agent.updateRotation = false;

        agent.speed = speed;
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
        if (!alerted)
        {
            // Rotate spotter
            float angle = Mathf.Sin(Time.time) * 30; // tweak this to change frequency
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

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
        print("OnCollisionEnter(" + collision.gameObject + ")");

        // if collided with by either a player or other enemy
        if (!alerted && collision.transform.gameObject.tag == "Player" || collision.transform.gameObject.tag == "Enemy" || collision.transform.gameObject.tag == "Bullet")
        {
            // function call
            BecomeAlerted();
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
        Debug.Log("Spotter Running!");

        // set status to alerted
        alerted = true;
        sniperLine.enabled = true;

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
        // Run if player is too close
        transform.LookAt(player.transform);

        // Adjust length of sniper line
        Vector3 sniperVec = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 playerVec = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        float distanceToPlayer = Vector3.Distance(sniperVec, playerVec);
        sniperLine.SetPosition(1, new Vector3(0, 0.1f, distanceToPlayer + 2));
    }
}