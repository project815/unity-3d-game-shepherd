using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningMessage : MonoBehaviour
{
    GameObject audio;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("AudioManager_Effect");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (0.1 <= timer  && timer <= 0.3)
        {
            GetComponent<RawImage>().color = new Color(1, 0, 0, 1);
            audio.GetComponent<EffectAudio>().EffectSound("Warnming");
        }
        else if(0.3 < timer)
        {
            timer = 0;
            GetComponent<RawImage>().color = new Color(1, 0, 0, 0);
        }

        //GetComponent<RawImage>().color =
        //    Color.Lerp(R.color, Color.clear, 0.01f);

    }
}
