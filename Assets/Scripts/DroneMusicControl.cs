using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMusicControl : MonoBehaviour
{

    [SerializeField] AudioClip droneMusic;

    AudioSource audioSource;

    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DroneStart"))
        {
            if (!isPlaying)
            {
                print("Drone music start");
                audioSource.Play();
                isPlaying = true;
            }
        }

        if (other.CompareTag("DroneStop"))
        {
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }

}
