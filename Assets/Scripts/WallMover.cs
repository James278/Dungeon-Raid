using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{

    public Animator slider;

    public bool move = false;

    AudioSource audioSource;

    private void Start()
    {
        slider = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveWall();
    }

    public void MoveWall()
    {
        if (move)
        {
            slider.SetTrigger("Move");
        }
        else if (move == false)
        {
            slider.ResetTrigger("Move");
        }
    }

    void PauseWallMoveEvent()
    {
        slider.enabled = false;
    }

    void PlayMoveWallSoundEvent()
    {
        audioSource.Play();
    }

    void StopWallSoundEvent()
    {
        audioSource.Stop();
    }

}
