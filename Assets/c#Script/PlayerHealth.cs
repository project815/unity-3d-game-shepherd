using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject GameoverMessage;
    public GameObject SpearCheackBox;
    public GameObject FireCheackBox;
    public GameObject AXCheackBox;

    GameObject audio;
    Transform PlayerHome;

    bool bDamage;
    public RawImage imgDamage;
    public Slider sliderHP;

    public float hp = 100;

    public float defensepower = 1.1f;
    void Start()
    {
        PlayerHome = GameObject.Find("PlayerHome").transform;
        audio = GameObject.Find("AudioManager_Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(bDamage)
        {
            imgDamage.color = new Color(1, 0, 0, 1);
        }
        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 0.01f);
        }
        bDamage = false;
    }


    public void Damage(float amount)
    {
        if(0 < PlayerHeartCount.count)
        {
            if (hp <= 0)
            {
                return;
            }
            hp -= amount / defensepower;
            Mathf.Lerp(sliderHP.value, 0, hp / 100);
            sliderHP.value = hp;
            bDamage = true;
            if (hp <= 0)
            {

                GetComponent<Animator>().SetTrigger("PlayerDeath");
                audio.GetComponent<PlayerAudio>().PlayerSound("PlayerDeath");

                GetComponent<PlayerHealth>().enabled = false;
                GetComponent<PlayerAttack>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;


                PlayerHeartCount.count -= 1;
                Invoke("Respawn", 3);
            }
        }    
        else if(PlayerHeartCount.count <= 0)
        {
            GameoverMessage.SetActive(true);
            GameOverMessage();
        }

    }
     public void GameOverMessage()
    {
        GrenadeCount.count = 0;
        PlayerHeartCount.count = 3;
        WolfCount.count = 13;

    }
    public void Healing(int HPPlus)
    {
        hp += HPPlus;
        if(hp > 100)
        {
            hp = 100;
        }
        sliderHP.value = hp;

    }
    void Respawn()
    {
        hp = 100;
        sliderHP.value = hp;

        transform.position = PlayerHome.position + new Vector3(-3, 0, 3);

        GetComponent<Animator>().SetTrigger("Respawn");

        GetComponent<PlayerHealth>().enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
        GetComponent<PlayerMove>().enabled = true;

    }


}