using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour
{
    Transform player;

    float distanceToTarget = Mathf.Infinity;

    [SerializeField] AudioClip lockedSound;
    [SerializeField] AudioClip openSound;

    [SerializeField] bool opened = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(player.position, transform.position);
}

    public void ChestOpener()
    {
                if (player.GetComponent<Inventory>().keysPickedUp == true && opened == false)
                {
                    animator.SetTrigger("Open");
                    AudioSource.PlayClipAtPoint(openSound, transform.position);
                    opened = true;
                }
                else if (player.GetComponent<Inventory>().keysPickedUp == false)
                {
                    AudioSource.PlayClipAtPoint(lockedSound, gameObject.transform.position);
                }
    }

    void DisableAnimatorEvent()
    {
        animator.enabled = false;
    }

}
