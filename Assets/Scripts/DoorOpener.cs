using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    Transform player;
    Animator openDoor;
    Interact interact;

    float distanceToTarget = Mathf.Infinity;

    [SerializeField] float openerRange = 2f;

    [SerializeField] AudioClip openSound;
    [SerializeField] AudioClip closeSound;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        openDoor = GetComponent<Animator>();
        interact = GameObject.FindObjectOfType<Interact>();
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(player.position, transform.position);

        if (distanceToTarget <= openerRange)
        {
            interact.interactText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (openDoor.enabled == false)
                {
                    openDoor.enabled = true;
                }
                else
                {
                    openDoor.SetTrigger("Open");
                }
            }
        }
    }

    public void OpenDoor()
    {
        if (openDoor.enabled == false)
        {
            openDoor.enabled = true;
        }
        else
        {
            openDoor.SetTrigger("Open");
        }
    }

    void PauseOpenDoorEvent()
    {
        openDoor.enabled = false;
    }

    void ResetTriggerEvent()
    {
        openDoor.ResetTrigger("Open");
    }

    void OpenDoorSoundEvent()
    {
        AudioSource.PlayClipAtPoint(openSound, gameObject.transform.position, 20f);
    }

    void CloseDoorSoundEvent()
    {
        AudioSource.PlayClipAtPoint(closeSound, gameObject.transform.position);
    }

}
