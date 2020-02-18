using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss1 : Character
{
    /// <summary>
    /// The percenntage of remaining health at which the boss enrages
    /// </summary>
    public float enragePoint;

    /// <summary>
    /// Array of enemies in the room available to clone
    /// </summary>
    public List<GameObject> enemies;

    /// <summary>
    /// Percentage chance that the boss will jump vs run or clone
    /// </summary>
    public float jumpChance;

    /// <summary>
    /// Percentage chance that the boss will clone vs run or jump
    /// </summary>
    public float cloneChance;

    /// <summary>
    /// How far the boss will walk at a time
    /// </summary>
    public float moveRadius;

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

    private Animator animator;
    private bool invulnerable;
    private float waitTime;
    private NavMeshAgent agent;
    private GameObject player;
    private bool waiting = false;
    private bool enraged = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.updateRotation = false;
    }

    public void FireCloneGun()
    {
        animator.SetBool("Fire Clone Gun", true);

        if(enemies.Count > 0)
        {
            StartCoroutine(CloneEnemies());
        }
        else
        {
            animator.SetBool("Fire Clone Gun", false);
        }
    }

    private void Jump()
    {
        agent.SetDestination(player.transform.position);
        animator.SetTrigger("Jump");
    }

    private void Run()
    {
        animator.SetFloat("Speed", 1f);
        agent.SetDestination(RandomNavMeshPoint());
    }

    protected override void Move()
    {
        waiting = false;
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

    private IEnumerator Wait()
    {
        waiting = true;

        yield return new WaitForSeconds(waitTime);

        Move();
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
        }

        yield return new WaitForSeconds(cloneTime);

        foreach(GameObject enemy in enemies)
        {
            var newEnemy = Instantiate(enemy);
            enemies.Add(newEnemy);
        }

        animator.SetBool("Fire Clone Gun", false);
    }
}
