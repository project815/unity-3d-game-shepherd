using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject AudioEffect;
    public GameObject AudioPlayer;
    public GameObject AudioManager;
    public GameObject AudioEnemy;

    public GameObject AudioPlayerAttack;


    public GameObject DisabledHUD;
    public GameObject DisableGetMessage;
    public GameObject DisableStickControl;
    public GameObject DisableItemInfo;

    
    void Start()
    {

        AudioEffect.SetActive(false);
        AudioPlayer.SetActive(false);
        AudioManager.SetActive(false);
        AudioEnemy.SetActive(false);
        DisabledHUD.SetActive(false);
        DisableGetMessage.SetActive(false);
        DisableStickControl.SetActive(false);
        DisableItemInfo.SetActive(false);
        Time.timeScale = 0;        
    }

    public void SoundMute()
    {
        AudioPlayerAttack.GetComponent<AudioSource>().enabled = false;
        AudioEffect.SetActive(false);
        AudioPlayer.SetActive(false);
        AudioManager.SetActive(false);
        AudioEnemy.SetActive(false);

    }
    public void SoundPlay()
    {
        AudioPlayerAttack.GetComponent<AudioSource>().enabled = true;
        AudioEffect.SetActive(true);
        AudioPlayer.SetActive(true);
        AudioManager.SetActive(true);
        AudioEnemy.SetActive(true);
    }
}
