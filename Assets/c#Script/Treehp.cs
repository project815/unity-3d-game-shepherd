using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treehp : MonoBehaviour
{
    public Slider sliderHp;
    public GameObject log;
    public float hp = 50;
    
    public void Damage(int amount)
    {
        if(hp <= 0)
        {
            return;
        }
        hp -= amount;
        sliderHp.value = hp;
        if(hp <= 0)
        {
            log.SetActive(true);
            Destroy(sliderHp.gameObject);
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
