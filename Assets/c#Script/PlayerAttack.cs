using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    float AttackTimer;
    float ThrowPower = 0;

    int count = 0;
    public int strength = 5;
    public GameObject grenadeObj;
    public GameObject SpearObj;
    public GameObject BombItemon;

    public GameObject []AttackRange;

    public AudioClip audioAttack;
    AudioSource audio;

    
    LineRenderer line;
    Transform shootPoint;
    Transform bombPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        shootPoint = transform.Find("ShootPoint");
        bombPoint = transform.Find("BombPoint");
        audio = GetComponent<AudioSource>();
    }


    void Shoot()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            Treehp t = hit.collider.GetComponent<Treehp>();
            if (e != null)
            {
                e.Damage(strength);
            }
            if(t!= null)
            {
                t.Damage(strength);
            }
            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1, hit.point);
        }
        else
        {
            line.enabled = true;
            line.SetPosition(0, shootPoint.position);
            line.SetPosition(1, shootPoint.position + ray.direction * 10);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(CrossPlatformInputManager.GetButtonDown("Fire") && timer > 1.2f)
        {
            timer = 0;
            GetComponent<Animator>().SetBool("bAttack", true);
            Shoot();
            audio.PlayOneShot(audioAttack);
        }
        else if(timer > 0.05f)
        {
            line.enabled = false;
            GetComponent<Animator>().SetBool("bAttack", false);

        }
        if(1<= GrenadeCount.count && GrenadeCount.count <=3)
        {
            GrenadeAttack();
            GetComponent<Animator>().SetBool("bBomb", false);

        }
        else
        {
            BombItemon.SetActive(false);
        }


    }
    public void StrengthUp(int num)
    {
        strength += num;
    }
    void GrenadeAttack()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            SpearObj.SetActive(false);
            GetComponent<Animator>().SetTrigger("BeforeThrow");
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire2") && timer > 0.5f)
        {

            timer = 0;
            GrenadeCount.count--;
            GameObject instantGrenade = Instantiate(grenadeObj, bombPoint.position, bombPoint.rotation);
            Rigidbody rigidGrenade = instantGrenade.GetComponent<Rigidbody>();

            rigidGrenade.AddForce(bombPoint.forward * ThrowPower, ForceMode.Impulse);
            rigidGrenade.AddTorque(Vector3.back * 1, ForceMode.Impulse);


            audio.PlayOneShot(audioAttack);
            for (int i = 0; i < AttackRange.Length; i++)
            {
                AttackRange[i].SetActive(false);
            }

            ThrowPower = 0;
            AttackTimer = 0;
            GetComponent<Animator>().SetTrigger("AfterThrow");

        }
        if (CrossPlatformInputManager.GetButton("Fire2"))
        {
            GetComponent<Animator>().SetTrigger("HoldThrow");

            AttackTimer += Time.deltaTime;
            
            if (AttackTimer > 0.5)
            {
                AttackRange[0].SetActive(true);
                ThrowPower = 1f;
            }
            if (AttackTimer > 1.0)
            {
                AttackRange[1].SetActive(true);
                ThrowPower = 3.5f;
            }
            if (AttackTimer > 1.5)
            {
                AttackRange[2].SetActive(true);
                ThrowPower = 6.7f;
            }
            if (AttackTimer > 2)
            {
                AttackRange[3].SetActive(true);
                ThrowPower = 8f;
            }
        }
        else if (timer > 0.05f)
        {
            line.enabled = false;
        }
    }
}
