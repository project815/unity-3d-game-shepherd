using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMove : MonoBehaviour
{
    GameObject audio;

    public float speed; //public 선언을 통해 유니티 엔진에서 볼 수 있음.
    public float jump_power;

    float hAxis; //Horizonta
    float vAxis; //Vertical

    bool rDown;
    bool isMove;
    bool isInWater;

    Vector3 MoveVec;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GameObject.Find("AudioManager_Player");
    }
    // Update is called once per frame
    void Update()
    {
        hAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        vAxis = CrossPlatformInputManager.GetAxis(("Vertical"));
        //hAxis = Input.GetAxis("Horizontal");
        //vAxis = Input.GetAxis("Vertical");

        MoveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += (speed * Time.deltaTime * MoveVec * (rDown ? 3f : 1f));
        transform.LookAt(transform.position + MoveVec);

        anim.SetBool("bMove", hAxis != 0 || vAxis != 0 ? true : false);

        Move();
        //if (isMove && !isInWater && !audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
        //{      
        //        audio.GetComponent<PlayerAudio>().PlayerSound("Walking");
        //}
        //else if (isMove && isInWater && !audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
        //{
        //    audio.GetComponent<PlayerAudio>().PlayerSound("WalkingInWater");
        //    if(!isInWater)
        //    {
        //        audio.GetComponent<PlayerAudio>().audiosource.Pause();
        //        audio.GetComponent<PlayerAudio>().PlayerSound("Walking");

        //    }
        //}
        //else if (!isMove)
        //{
        //    audio.GetComponent<PlayerAudio>().audiosource.Pause();
        //}
        if (isMove)
        {
            if(!isInWater && !audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
            {
                audio.GetComponent<PlayerAudio>().PlayerSound("Walking");
            }
            else if(isInWater && !audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
            {
                audio.GetComponent<PlayerAudio>().PlayerSound("WalkingInWater");
            }
            else if (isInWater && audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
            {
                audio.GetComponent<PlayerAudio>().audiosource.Pause();
                audio.GetComponent<PlayerAudio>().PlayerSound("WalkingInWater");
            }
            else if (!isInWater && audio.GetComponent<PlayerAudio>().audiosource.isPlaying)
            {
                audio.GetComponent<PlayerAudio>().audiosource.Pause();
                audio.GetComponent<PlayerAudio>().PlayerSound("Walking");
            }
        }
        //else if(Input.GetButtonUp("SoundButton"))
        //{
        //    audio.GetComponent<PlayerAudio>().audiosource.Pause();
        //}
        if (!isMove)
        {
            audio.GetComponent<PlayerAudio>().audiosource.Pause();
        }


    }
    public void itemGathering()
    {
        anim.SetTrigger("tGathering");
        
    }

    void Move()
    {
        if (hAxis != 0 || vAxis != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isInWater = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag =="Water")
        {
            isInWater = false;
        }
    }

}