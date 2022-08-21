using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Slider slider;

    float start_timer;
    float stop_timer;
    
    public float [] Stop_time;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Stop_Timer();
    }
        
    void Timer()
    {
        start_timer += Time.deltaTime;

        if (start_timer >= 1)
        {
            slider.value += start_timer;
            start_timer = 0;

        }
    }
    void Stop_Timer()
    {
        stop_timer += Time.deltaTime;

        if (start_timer >= 1)
        {
            slider.value += start_timer;
            stop_timer = 0;

        }
    }

}


