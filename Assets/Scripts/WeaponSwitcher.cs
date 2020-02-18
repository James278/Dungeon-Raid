using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    [SerializeField] int currentWeapon = 1;

    [SerializeField] TextMeshProUGUI staffAmmo;
    [SerializeField] TextMeshProUGUI swordAmmo;

    // Start is called before the first frame update
    void Start()
    {
        staffAmmo.gameObject.SetActive(false);
        swordAmmo.gameObject.SetActive(false);
        SetWeaponActive();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessMouseWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                swordAmmo.gameObject.SetActive(false);
                staffAmmo.gameObject.SetActive(false);

                weapon.gameObject.SetActive(true);
                if (currentWeapon == 1)
                {
                    swordAmmo.gameObject.SetActive(true);
                }
                if (currentWeapon == 2)
                {
                    staffAmmo.gameObject.SetActive(true);
                }
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    private void ProcessMouseWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }

}
