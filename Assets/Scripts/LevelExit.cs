using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    Inventory playerInventory;

    private void Start()
    {
        GetComponent<Collider>().enabled = false;
        playerInventory = GameObject.FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (playerInventory.blackHelmPickedUp == true)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            GetComponent<LevelManager>().LoadNextLevel();
        }
    }

}
