using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pat : MonoBehaviour
{
    Transform playerhome;
    Transform player;
    NavMeshAgent nav;

    Vector3 posReturn;

    public float maxDist;
    public float minDist;

    // Start is called before the first frame update
    void Start()
    {
        playerhome = GameObject.Find("PlayerHome").transform;
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        posReturn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //nav.SetDestination(player.position);
        float Dist = Vector3.Distance(posReturn, player.position);
        if (Dist > maxDist)
        {
            nav.SetDestination(posReturn);
            if(Vector3.Distance(player.position, posReturn) > 0)
            {
                GetComponent<Animator>().SetBool("bWalk", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("bWalk", false);
            }

        }
        else if (Dist > minDist)
        {
            nav.SetDestination(player.position);
        }

    }
}
