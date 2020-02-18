using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchReLight : MonoBehaviour
{

    TorchDecay torchDecay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTorch"))
        {
            print("Torch relit");
            torchDecay = other.GetComponentInParent<TorchDecay>();

            other.GetComponentInParent<TorchDecay>().RelightTorch();
        }
    }

}
