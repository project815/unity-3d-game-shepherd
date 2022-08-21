using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip Attack;
    public AudioClip PlayerDeath;
    public AudioClip PlayerWalking;
    public AudioClip WalkingInWater;
    
    public AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();

    }
    public void PlayerSound(string action)
    {
        switch(action)
        {
            case "Attack":
                audiosource.clip = Attack;
                break;
            case "PlayerDeath":
                audiosource.clip = PlayerDeath;
                break;
            case "Walking":
                audiosource.clip = PlayerWalking;
                break;
            case "WalkingInWater":
                audiosource.clip = WalkingInWater;
                break;
        }
        audiosource.Play();

    }

}
