using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartCount : MonoBehaviour
{
    public static int count = 3;
    Text PlayerHeartText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHeartText = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHeartText.text = "x " + count;
    }
}
