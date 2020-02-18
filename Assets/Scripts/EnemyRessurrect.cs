using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRessurrect : MonoBehaviour
{

    EnemyHealth enemyHealth;

    Animator anim;

    Inventory playerInv;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        playerInv = GameObject.FindObjectOfType<Inventory>();

        anim.SetTrigger("Dead");
        enemyHealth.isDead = true;
    }

    private void Update()
    {

    }

    public void Ressurrect()
    {
        enemyHealth.isDead = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
        anim.SetTrigger("Ressurrect");
    }

}
