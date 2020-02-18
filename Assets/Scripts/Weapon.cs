using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 200f;
    [SerializeField] float powerupSpeed;
    [SerializeField] float ammoReduceSpeed;

    [SerializeField] ParticleSystem staffFlash;
    [SerializeField] GameObject staffImpactFlash;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    
    [SerializeField] float weaponDamage;
    [SerializeField] float timer;

    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] AudioClip impact;

    AudioSource audioSource;

    bool isPlaying = false;

    float ammoReduceAmount = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DisplayAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            ammoText.enabled = true;
        }
        else
        {
            ammoText.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
            {
                PlayStaffFlash();
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
            if (timer <= 3f)
            {
                timer += Time.deltaTime;
                weaponDamage += powerupSpeed * Time.deltaTime;
                ammoReduceAmount += ammoReduceSpeed * Time.deltaTime;
            }

            else
            {
                return;
            }
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
            StopStaffFlash();
            if (ammoSlot.GetCurrentAmmoAmount(ammoType) > 0)
            {
                ProcessRaycast();
                AudioSource.PlayClipAtPoint(impact, gameObject.transform.position, 10f);
                ammoSlot.ReduceCurrentAmmoAmount(Mathf.Ceil(ammoReduceAmount), ammoType);
            }
            else if (ammoSlot.GetCurrentAmmoAmount(ammoType) <= 0)
            {
                return;
            }

            DisplayAmmo();
            ResetLevers();
        }
    }

    public void DisplayAmmo()
    {
        float currentAmmo = ammoSlot.GetCurrentAmmoAmount(ammoType);
        ammoText.text = currentAmmo.ToString();       
    }

    private void PlayStaffFlash()
    {
        staffFlash.gameObject.SetActive(true);
    }

    private void StopStaffFlash()
    {
        staffFlash.gameObject.SetActive(false);
    }

    private void ProcessRaycast()
    {
        RaycastHit target;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out target, range))
        {
            var enemy = target.transform.GetComponent<EnemyHealth>();

            CreateImpactParticle(target);
            
            if (enemy == null)
            {
                return;
            }
            enemy.takeDamage(Mathf.Ceil(weaponDamage));
            target.transform.GetComponent<EnemyAI>().isProvoked = true;
        }
        else
        {
            return;
        }
    }

    private void ResetLevers()
    {
        weaponDamage = 0f;
        timer = 0f;
        ammoReduceAmount = 0;
    }

    void CreateImpactParticle(RaycastHit target)
    {
        GameObject impact = Instantiate(staffImpactFlash, target.point, Quaternion.identity);
        Destroy(impact, 4f);       
    }
}
