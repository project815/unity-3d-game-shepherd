using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputItem : MonoBehaviour
{
    bool isInPlayer;
    public GameObject targetObject;


    void Update()
    {
        if(isInPlayer)
        {
            targetObject.SetActive(true);
            
        }
        else
        {
            targetObject.SetActive(false);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInPlayer = true;
        }
        if(other.gameObject.tag == "Fire")
        {
            isInPlayer = true;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInPlayer = false;
        }
        if (other.gameObject.tag == "Fire")
        {
            isInPlayer = false;

        }
    }
}
