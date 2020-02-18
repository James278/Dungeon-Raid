using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoverTrigger : MonoBehaviour
{

    WallMover wallMover;
    AudioSource audisoSource;

    // Start is called before the first frame update
    void Start()
    {
        wallMover = GameObject.FindObjectOfType<WallMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            print("Trapped!");
            if (wallMover.move == false)
            {
                wallMover.move = true;
            }
        }
    }

}
