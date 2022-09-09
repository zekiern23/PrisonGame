using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterMove : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    public float _speed;
    Animator charanim;
    private bool kosuyormuyum;

    void Start()
    {
       charanim= GetComponent<Animator>();
       kosuyormuyum =false;
    }


    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(_horizontal*_speed*Time.deltaTime,0,_vertical*_speed*Time.deltaTime);

        if(_horizontal!=0)
        {
            kosuyormuyum =true;
        }

        charanim.SetBool("Walking", kosuyormuyum);
    }
}
