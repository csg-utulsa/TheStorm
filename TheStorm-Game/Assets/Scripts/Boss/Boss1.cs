using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss1 : Character
{
    [Header("Boss Attributes")]
    /// <summary>
    /// The percenntage of remaining health at which the boss enrages
    /// </summary>
    public float enragePoint;

    /// <summary>
    /// Array of enemies in the room available to clone
    /// </summary>
    public List<GameObject> enemies;

    /// <summary>
    /// How far the boss will walk at a time
    /// </summary>
    public float moveRadius;

    [Header("State Chances")]
    /// <summary>
    /// Percentage chance that the boss will jump vs run or clone
    /// </summary>
    [Range(0,.5f)]
    public float jumpChance;

    /// <summary>
    /// Percentage chance that the boss will clone vs run or jump
    /// </summary>
    [Range(0,.5f)]
    public float cloneChance;

    [Header("Cloning Attributes")]
    /// <summary>
    /// How many enemies the boss clones normally
    /// </summary>
    public int numEnemiesCloned;

    /// <summary>
    /// How many enemies the boss clones while enraged
    /// </summary>
    public int numEnemiesClonedEnraged;

    /// <summary>
    /// How many seconds it takes to clone an enemy
    /// </summary>
    public float cloneTime;

    /// <summary>
    /// Prefab for the clone ray effect
    /// </summary>
    public GameObject cloneRayPrefab;

    private Animator animator;
    private bool invulnerable;
    private float waitTime;
    private NavMeshAgent agent;
    private GameObject player;
    private bool enraged = false;
    private bool moveLock = false;

    private void Awake()
    {
        animator = transform.GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = transform.GetComponentInParent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
    }

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
    }

    public void FireCloneGun()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if(i >= enemies.Count)
            {
                break;
            }

            if(enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }

            i--;
        }

        animator.SetBool("Fire Clone Gun", true);
        Debug.Log("Clone Gun");
        if(enemies.Count > 0)
        {
            Debug.Log("Start Coroutine");
            StartCoroutine(CloneEnemies());
        }
        else
        {
            animator.SetBool("Fire Clone Gun", false);
        }
    }

    public void FireJumpGun()
    {
        ((Boss1Gun)weapon).JumpGun();
    }

    private void Jump()
    {
        agent.SetDestination(player.transform.position);
        animator.SetTrigger("Jump");
    }

    private void Run()
    {
        StartAttack();
        animator.SetFloat("Speed", 1f);
        agent.SetDestination(RandomNavMeshPoint());
    }

    protected override void Move()
    {
        if(!moveLock)
        {
            moveLock = true;

            float rand = Random.value;

            Debug.Log(rand);

            if (rand <= jumpChance)
            {
                Jump();
            }
            else if (rand >= 1 - cloneChance)
            {
                FireCloneGun();
            }
            else
            {
                Run();
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        if (invulnerable)
            return;

        base.TakeDamage(damage);

        if(!enraged && health/maxHealth <= enragePoint)
        {
            animator.SetTrigger("Enrage");
            enraged = true;
        }
    }

    public void SetInvulnerable(bool iv)
    {
        invulnerable = iv;
    }

    private Vector3 RandomNavMeshPoint()
    {
        Vector3 randomPos = Random.insideUnitSphere * moveRadius + transform.position;

        NavMeshHit hit;

        NavMesh.SamplePosition(randomPos, out hit, moveRadius, NavMesh.GetAreaFromName("Boss Area"));

        return hit.position;
    }

    public void StopWaiting()
    {
        Move();
    }

    public void StopMove()
    {
        moveLock = false;
        StopAttack();
    }

    private IEnumerator CloneEnemies()
    {
        int limit = numEnemiesCloned;

        if(enraged)
        {
            limit = numEnemiesClonedEnraged;
        }

        GameObject[] clonedEnemies = new GameObject[limit];

        for(int i = 0; i < limit; i++)
        {
            int rand = Random.Range(0, enemies.Count);

            clonedEnemies[i] = enemies[rand];

            enemies[rand].GetComponentInChildren<Character>().ChangeSpeed(0, cloneTime);

            var ray = Instantiate(cloneRayPrefab);

            ray.GetComponent<CloneRay>().setTargets(transform.position, clonedEnemies[i].transform.position);

            Destroy(ray, cloneTime);
        }

        yield return new WaitForSeconds(cloneTime);

        foreach(GameObject enemy in clonedEnemies)
        {
            var newEnemy = Instantiate(enemy);
            enemies.Add(newEnemy);
        }

        Debug.Log("test");

        animator.SetBool("Fire Clone Gun", false);

        StopMove();
    }
}
