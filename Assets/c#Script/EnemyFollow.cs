using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    GameObject sheep;

    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        sheep = GameObject.Find("Sheep");    
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav != null)
        {
            nav.SetDestination(sheep.transform.position);
        }
    }
}
