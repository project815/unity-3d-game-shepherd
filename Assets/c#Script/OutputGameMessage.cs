using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputGameMessage : MonoBehaviour
{

    public Slider timer;

    public GameObject GameMessage1;
    public GameObject GameMessage2;


    // Update is called once per frame
    void Update()
    {
        if(0 <= timer.value && timer.value <= 3)
        {
            GameMessage1.SetActive(true);
        }
        if(4 < timer.value)
        {
            GameMessage1.SetActive(false);
        }
        if (4 < timer.value && timer.value < 10)
        {
            GameMessage2.SetActive(true);
        }
        if (10 < timer.value)
        {
            GameMessage2.SetActive(false);
        }
    }
}
