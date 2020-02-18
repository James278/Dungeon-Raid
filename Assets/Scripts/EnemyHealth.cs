using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float enemyHealthPoints;

    public bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthPoints <= 0f)
        {
            if (isDead)
            {
                return;
            }
                isDead = true;
                GetComponent<Animator>().SetTrigger("Dead");
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    public void takeDamage(float damage)
    {
        enemyHealthPoints -= damage;
        BroadcastMessage("OnDamageTaken");
    }

    public bool IsDead()
    {
        return isDead;
    }

}
