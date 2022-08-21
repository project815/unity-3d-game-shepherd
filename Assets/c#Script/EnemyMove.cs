using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    public GameObject GameWinMessage;
    public GameObject GameoverMessage;
    public GameObject WarningMessage;
    public Slider silderTime;
    NavMeshAgent nav;
    Transform player;
    Transform sheep;

    public Transform[] pos;

    int i = 0;

    bool isPlayer;
    bool isSheep;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        sheep = GameObject.Find("Sheep").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, pos[i].position);
        if (dist <= 1)
        {
            if (++i >= pos.Length)
            {
                i = 0;
            }
        }


        PlayerDistanceInOut();
        WolfDistanceInOut();

        if (0 <= silderTime.value && silderTime.value <= 120)
        {

            if (isPlayer && isSheep)
            {
                nav.SetDestination(player.position);
            }
            if (!isPlayer || !isSheep || GameObject.Find("Player").GetComponent<PlayerHealth>().hp <= 0
                || GameObject.Find("Sheep").GetComponent<PatHealth>().hp <= 0)
            {
                nav.SetDestination(pos[i].position);
            }
        }
        if(115 <= silderTime.value && silderTime.value <= 122)
        {
            WarningMessage.SetActive(true);

            //audio
        }
        if (120 < silderTime.value)
        {
            WarningMessage.SetActive(false);


            if (isSheep)
            {
                nav.SetDestination(sheep.position);
            }
            if (!isSheep || GameObject.Find("Sheep").GetComponent<PatHealth>().hp <= 0)
            {
                nav.SetDestination(pos[i].position);
            }

        }
        if(180 <= silderTime.value)
        {
            GrenadeCount.count = 0;
            GameoverMessage.SetActive(true);
        }
        if(WolfCount.count <= 0 && silderTime.value < 180)
        {
            GameWinMessage.SetActive(true);
        }
    }

    public void PlayerDistanceInOut()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist < 5)
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;

        }
    }

    public void WolfDistanceInOut()
    {
        float dist = Vector3.Distance(transform.position, sheep.position);
        if (dist < 100)
        {
            isSheep = true;

        }
        else
        {
            isSheep = false;

        }
    }
}
