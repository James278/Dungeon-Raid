using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float chaseRangeUpdate = 10f;
    [SerializeField] float turnSpeed;

    Transform player;
    EnemyHealth enemyHealth;
    NavMeshAgent navMeshAgent;
    float chaseRangeDefault;
    float distanceToTarget = Mathf.Infinity;

    public bool isProvoked = false;

    bool soundPlaying = false;

    [SerializeField] float timer;

    [SerializeField] AudioClip skeletonSFX;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        enemyHealth = GetComponent<EnemyHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        chaseRangeDefault = chaseRange;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            navMeshAgent.enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            StopSoundFX();
        }

        distanceToTarget = Vector3.Distance(player.position, transform.position);

        if (isProvoked)
        {
            if (enemyHealth.IsDead() == false)
            {
                EngageTarget();
            }
        }
        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        else if (distanceToTarget > chaseRange)
        {
            chaseRange = chaseRangeDefault;
            isProvoked = false;
            GetComponent<AudioSource>().Stop();
            StopSoundFX();
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
                ChasePlayer();
        }
        else if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
                AttackPlayer();            
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChasePlayer()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(player.position);
        navMeshAgent.isStopped = false;
        chaseRange = chaseRangeUpdate;
        if (!soundPlaying)
        {
            soundPlaying = true;
            audioSource.Play();
        }
    }

    void AttackPlayer()
    {
        if (soundPlaying)
        {
            soundPlaying = false;
            audioSource.Stop();
        }
        GetComponent<AudioSource>().Stop();
        navMeshAgent.isStopped = true;
        GetComponent<Animator>().SetBool("Attack", true);
        //timer += Time.deltaTime;
        //if (timer >= .99 && timer <= 1.03)
        //{
        //    player.GetComponent<PlayerHealth>().TakeDamage(10f);
        //}
        //if (timer >= 2.23f)
        //{
        //    timer = 0f;
        //}
    }
    
    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void StopSoundFX()
    {
        if (soundPlaying)
        {
            soundPlaying = false;
            audioSource.Stop();
        }
    }

}
