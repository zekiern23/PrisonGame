using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharMove : MonoBehaviour
{
    UnityEngine.Vector3 move;

    Animator charanim;
    float max_speed;
    float axisZ;
    Camera maincam;

    void Start()
    {
        charanim= GetComponent<Animator>();
        maincam = Camera.main;

    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            max_speed= 0.2f;
            axisZ=max_speed*Input.GetAxis("Vertical");

            if(Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.W))
            {
                max_speed= 1f;
                axisZ=max_speed*Input.GetAxis("Vertical");
            }
        
        if(Input.GetKeyDown(KeyCode.A)&& Input.GetKey(KeyCode.W))
        {
            charanim.SetBool("turn_left",true);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            charanim.SetBool("turn_left",false);
        }
        if(Input.GetKeyDown(KeyCode.D)&& Input.GetKey(KeyCode.W))
        {
            charanim.SetBool("turn_right",true);
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            charanim.SetBool("turn_right",false);
        }
        }
        else
        {
            max_speed= 0f;
            axisZ=max_speed*Input.GetAxis("Vertical");
        }
        

        Vector3 vector = new Vector3(0,0,axisZ);

        charanim.SetFloat("Speed", Vector3.ClampMagnitude(vector,1).magnitude,1f,Time.deltaTime*3f);

        //Vector3 cameradirection = maincam.transform.forward;
        Vector3 cameradirection = maincam.transform.TransformDirection(vector);
        cameradirection.y = 0f;
        transform.forward = Vector3.Slerp(transform.forward,cameradirection,Time.deltaTime*10f);
    }
}
