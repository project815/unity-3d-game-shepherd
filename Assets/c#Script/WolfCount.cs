using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfCount : MonoBehaviour
{
    public static int count = 13;
    Text WolfLeftCount;
    // Start is called before the first frame update
    void Start()
    {
        WolfLeftCount = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        WolfLeftCount.text = "x " + count;


    }
}

