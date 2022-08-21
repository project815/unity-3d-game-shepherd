using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject meshObj;
    public GameObject effectObj;
    public Rigidbody rigid;

    GameObject BombEffectSound;
    // Start is called before the first frame update
    void Start()
    {
        BombEffectSound = GameObject.Find("AudioManager_Effect");
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(3f);
        rigid.velocity = Vector3.zero; 
        rigid.angularVelocity = Vector3.zero;
        effectObj.SetActive(true);
        Destroy(meshObj, 2);
        BombEffectSound.GetComponent<EffectAudio>().EffectSound("Bomb");
        
        RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, 5, 
            Vector3.up, 0f, 
            LayerMask.GetMask("Shootable"));
        foreach(RaycastHit hitObj in rayHits)
        {
            hitObj.transform.GetComponent<EnemyHealth>().HitByGrenade(transform.position);
        }

    }
}
