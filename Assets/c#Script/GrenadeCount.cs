using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrenadeCount : MonoBehaviour
{
    public static int count = 0;
    Text Grenadetext;
    // Start is called before the first frame update
    void Start()
    {
        Grenadetext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Grenadetext.text = "x " + count;
    }
}
