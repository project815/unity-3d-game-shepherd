using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    
    public GameObject Spear;
    public GameObject Fire;
    public GameObject Bomb;
    public GameObject Armor;
    public GameObject TreeFence;
    public GameObject Ax;

    public GameObject SilderHPbar_Tree;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {

    }
    
    public void SpearItemeqip()
    {

        Spear.SetActive(true);
        GetComponent<PlayerAttack>().StrengthUp(15);
    }

    public void SpearItemeqipoff()
    {

        Spear.SetActive(false);
        GetComponent<PlayerAttack>().StrengthUp(-15);
    }
    public void FireItemequip()
    {

        Fire.SetActive(true);
        GetComponent<PlayerAttack>().StrengthUp(15);
        
    }
    public void FireItemequipoff()
    {

        Fire.SetActive(false);
        GetComponent<PlayerAttack>().StrengthUp(-15);

    }

    public void AxItemequipon()
    {
        Ax.SetActive(true);
        GetComponent<PlayerAttack>().StrengthUp(20);

    }
    public void AxItemequipoff()
    {
        Ax.SetActive(false);
        GetComponent<PlayerAttack>().StrengthUp(-20);

    }



    public void BombItemequip()
    {
            Bomb.SetActive(true);
            Armor.SetActive(true);
            GetComponent<PlayerHealth>().defensepower = 4.0f;
            GrenadeCount.count += 3;
    }
    public void MakeFence()
    {
        TreeFence.SetActive(true);
    }
}
