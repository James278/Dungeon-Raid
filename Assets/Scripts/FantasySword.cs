using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FantasySword : MonoBehaviour
{

    Animator animator;
    EnemyHealth enemy;
    Collider sphereCollider;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    bool isTriggerOn;

    [SerializeField] float poweredWeaponDamage = 10f;
    [SerializeField] float normalWeaponDamage = 2f;

    [SerializeField] Transform playerTransform;

    [SerializeField] ParticleSystem swordGlow;

    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] AudioClip swordSwing;
    [SerializeField] AudioClip swordHit;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.FindObjectOfType<EnemyHealth>();
        sphereCollider = GetComponent<Collider>();

        isTriggerOn = false;

        audioSource = GetComponent<AudioSource>();

        DisplayAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
        {
            swordGlow.gameObject.SetActive(true);
        }
        else if(ammoSlot.GetCurrentAmmoAmount(ammoType) <= 0)
        {
            swordGlow.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("Raise", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("Raise", false);
            animator.SetTrigger("Strike");
        }

        if (isTriggerOn == true)
        {
            sphereCollider.isTrigger = true;
        }
        else if (isTriggerOn == false)
        {
            sphereCollider.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>())
        {

            print(other.name + " hit");
            AudioSource.PlayClipAtPoint(swordHit, gameObject.transform.position, 10f);
            if (ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
            {
                other.GetComponent<EnemyHealth>().takeDamage(poweredWeaponDamage);
                ammoSlot.ReduceCurrentAmmoAmount(1f, ammoType);
            }
            else if (ammoSlot.GetCurrentAmmoAmount(ammoType) <= 0)
            {
                other.GetComponent<EnemyHealth>().takeDamage(normalWeaponDamage);
            }
            DisplayAmmo();
        }

    }

    public void DisplayAmmo()
    {
        float currentAmmo = ammoSlot.GetCurrentAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    void IsTriggerToggleEvent()
    {
        if (isTriggerOn == true)
        {
            isTriggerOn = false;
        }
        else if (isTriggerOn == false)
        {
            isTriggerOn = true;
        }
    }

    void SwordSFXEvent()
    {
        audioSource.Play();
    }

    void DealDamageEvent()
    {
        if (enemy == null)
        {
            return;
        }
        enemy.takeDamage(poweredWeaponDamage);
    }

}
