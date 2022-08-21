using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackToSheep : MonoBehaviour
{
    GameObject Sheep;
    GameObject audio;

    bool bInRangeSheep;
    float time;

    void OnTriggerStay(Collider other)
    {    
        if (other.gameObject.tag == "Sheep")
        {
            bInRangeSheep = true;
        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Sheep")
        {
            bInRangeSheep = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Sheep = GameObject.Find("Sheep");
        audio = GameObject.Find("AudioManager_Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (bInRangeSheep && time > 1f)
        {

            SheepAttack();
        }
        else if (!bInRangeSheep)
        {
            GetComponent<Animator>().SetBool("PlayerAttack", false);
        }

    }
    void SheepAttack()
    {
        time = 0;
        Sheep.GetComponent<PatHealth>().Damage(10);
        GetComponent<Animator>().SetBool("SheepAttack", true);
        if (!audio.GetComponent<EnemyAudio>().audiosource.isPlaying)
        {
            audio.GetComponent<EnemyAudio>().EnemySound("Attack");
        }
        if (Sheep.GetComponent<PatHealth>().hp <= 0)
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
        }
    }
}
