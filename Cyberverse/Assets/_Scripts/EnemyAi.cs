using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private Animator animator;
    private AudioSource gunAudio;

    public GameObject enemyBullet;
    public Transform spawnPoint;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float bulletVelocity = 10f;
    private float playerHeightOffset = 1;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Health
    public float health = 50;

    private void Awake()
    {
        player = GameObject.Find("PlayerArmature").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        gunAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    /*private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if(walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }*/

    /*private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(walkPointRange - walkPointRange, walkPointRange);
        float randomX = Random.Range(walkPointRange - walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }*/

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Making the enemy not move when shooting
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            //Attack Function
            ShootAtPlayer(player.transform);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    void ShootAtPlayer(Transform playerTransform)
    {
        gunAudio.PlayOneShot(gunAudio.clip);

        // Calculate direction towards the player
        Vector3 direction = (playerTransform.position + Vector3.up * playerHeightOffset - spawnPoint.transform.position).normalized;

        // Instantiate the bullet
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, Quaternion.LookRotation(direction)) as GameObject;

        // Get the bullet Rigidbody
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();

        // Add force in the direction of the player
        bulletRig.AddForce(direction * bulletVelocity);

        // Destroy the bullet after a delay
        Destroy(bulletObj, 1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health<0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, sightRange);
    }

}
