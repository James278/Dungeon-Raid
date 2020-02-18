using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] FantasySword fantasySword;

    public AmmoPickup staffAmmoPickup;
    public AmmoPickup swordAmmoPickup;

    [SerializeField] TextMeshProUGUI staffAmmo;
    [SerializeField] TextMeshProUGUI swordAmmo;

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public float ammoAmount;
    }

    public float GetCurrentAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmoAmount(float reducedAmount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount - reducedAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, float ammoIncrease)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoIncrease;
        weapon.DisplayAmmo();
        fantasySword.DisplayAmmo();
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot ammoSlot in ammoSlots)
        {
            if (ammoSlot.ammoType == ammoType)
            {
                return ammoSlot;
            }
        }
        return null;
    }

}
