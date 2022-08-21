using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    GameObject audio;
    bool bInRangePlayer;

    float time;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bInRangePlayer = true;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bInRangePlayer = false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        audio = GameObject.Find("AudioManager_Enemy");
    }

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if(bInRangePlayer && time > 1f)
        {
            GetComponent<Animator>().SetBool("PlayerAttack", true);
            
            PlayerAttack();
        }
        else if (!bInRangePlayer)
        {
            GetComponent<Animator>().SetBool("PlayerAttack", false);
        }

    }
    void PlayerAttack()
    {
        time = 0;
        player.GetComponent<PlayerHealth>().Damage(10);
        GetComponent<Animator>().SetBool("PlayerAttack", true);
        if (!audio.GetComponent<EnemyAudio>().audiosource.isPlaying)
        {
            audio.GetComponent<EnemyAudio>().EnemySound("Attack");
        }
        if (player.GetComponent<PlayerHealth>().hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
        }

    }

}
