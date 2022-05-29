/*
    Configurer les anim par rapport aux vecteur Horiozntal et Vertical;

*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CharacterController cc;

    [SerializeField] float gravity = 1;
    [SerializeField] float speed = 5;

    [SerializeField] bool isWalking;
    [SerializeField] bool isRun;

    Vector3 move;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        MoveInput();
        TransitionAnim();
        cc.Move(move * Time.deltaTime);
        //Debug.Log(speed);
    }

    private void MoveInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Debug.Log(horizontal);
        Debug.Log(vertical);
        if(horizontal != 0 ||vertical != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        

        Gravity();
        Sprint();

        move = new Vector3(horizontal * speed, move.y, vertical * speed);
    }

    private void Gravity()
    {
        if(!cc.isGrounded){ return; }
        move.y -= gravity;
    }

    private void Sprint()
    {
        if(Input.GetButton("Fire3"))//leftshit
        {            
            speed +=0.1f;
            isRun = true;
            if(speed>10)
            {
                speed=10;
            }                        
        }
        else
        {
            isRun = false;
            if(speed>5)
            {
                speed -=0.1f;
            }
        }        
    }

    private void TransitionAnim()
    {
        anim.SetBool("Is Walking",isWalking);
        anim.SetBool("Is Run",isRun);
    }
}
