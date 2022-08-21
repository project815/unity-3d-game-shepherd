using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioClip audioAttack;
    public AudioClip audioDeath;

    public AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();

    }
    public void EnemySound(string action)
    {
        switch (action)
        {
            case "Attack":
                audiosource.clip = audioAttack;
                break;
            case "Death":
                audiosource.clip = audioDeath;
                break;

        }
        audiosource.Play();
    }

    public void EnemySoundMute(string action)
    {

        switch (action)
        {
            case "Attack":
                audiosource.clip = audioAttack;
                break;
            case "Death":
                audiosource.clip = audioDeath;
                break;

        }
        audiosource.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
