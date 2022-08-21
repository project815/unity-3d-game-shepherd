using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DisableImabar;

    GameObject Audio;
    public RawImage imgBar;
    public RawImage imgBlood;

    int hp = 100;
    bool isDeath;

    
    public void Damage(int amount)
    {
        if(hp <= 0)
        {
            return;
        }
        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp / 100f, 1, 1);

        if(hp <= 0)
        {
            
            WolfCount.count--;
            Audio.GetComponent<EnemyAudio>().EnemySound("Death");
            GetComponent<Animator>().SetTrigger("Death");

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyAttack>().enabled = false;
            imgBar.transform.localScale = new Vector3(0, 1, 1);
            DisableImabar.SetActive(false);
            isDeath = true;
        }
       
    }

    public void HitByGrenade(Vector3 expostionPos)
    {
        Damage(100);
        Vector3 reactVec = transform.position - expostionPos;

    }

    // Start is called before the first frame update
    void Start()
    {
        Audio = GameObject.Find("AudioManager_Enemy");
    }

    // Update is called once per frame
    void Update()
    {
            imgBlood.color = Color.Lerp(imgBlood.color, new Color(1, 0, 0, 1), 0.001f);
        if(isDeath)
        {

        }
        else
        {
            imgBlood.color = new Color(1, 0, 0, 0);
        }
    }
}
