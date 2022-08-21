using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;
public class GameEndingCount : MonoBehaviour
{
    public Slider Timer;
    Text CurrentTime;

    int Count = 10;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = GetComponent<Text>();
    }
    public void Update()
    {
        float lefttime = 180.0f - Timer.value;

        
        CurrentTime.text = ":   " + System.Math.Truncate(lefttime * 100) / 100 + " " + " SEC";
    }
}


