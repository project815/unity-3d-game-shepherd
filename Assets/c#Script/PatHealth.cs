using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatHealth : MonoBehaviour
{
    public GameObject GameoverMessage;
    public float hp = 100;
    public Slider silderHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damage(float amount)
    {
        if(hp <= 0)
        {
            return;
        }
        hp -= amount;
        silderHP.value = hp;
        if (hp <= 0)
        {
            GameoverMessage.SetActive(true);
            GrenadeCount.count = 0;
            PlayerHeartCount.count = 3;
            GetComponent<GameOverInfo>().OffGame();
            GetComponent<PatHealth>().enabled = false;
            GetComponent<Pat>().enabled = false;

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
