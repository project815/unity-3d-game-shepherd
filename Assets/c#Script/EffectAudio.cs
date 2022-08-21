using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAudio : MonoBehaviour
{
    public AudioClip ButtonDown;
    public AudioClip GameOver;
    public AudioClip GameWin;
    public AudioClip Bomb;
    public AudioClip WarnmingMessage;
    
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        this.audiosource = GetComponent<AudioSource>();
    }

    public void EffectSound(string action)
    {
        switch(action)
        {
            case "ButtonDown":
                audiosource.clip = ButtonDown;
                break;
            case "GameOver":
                audiosource.clip = GameOver;
                break;
            case "GameWin":
                audiosource.clip = GameWin;
                break;
            case "Bomb":
                audiosource.clip = Bomb;
                break;
            case "Warnming":
                audiosource.clip = WarnmingMessage;
                break;
        }    
        audiosource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
