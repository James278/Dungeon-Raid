using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth attackTarget;
    [SerializeField] float attackDamage = 10f;

    [SerializeField] AudioClip swordSwingSFX;

    // Start is called before the first frame update
    void Start()
    {
        attackTarget = GameObject.FindObjectOfType<PlayerHealth>();
    }

    void DealDamageEvent()
    {
        if (attackTarget == null)
        {
            return;
        }
        attackTarget.TakeDamage(attackDamage);
    }

    void SwordSFXEvent()
    {
        AudioSource.PlayClipAtPoint(swordSwingSFX, transform.position);
    }

}
