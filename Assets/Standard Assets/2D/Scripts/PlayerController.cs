﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Animator animator;                  //Used to store a reference to the Player's animator component.          
    private Rigidbody2D rbody;
    private Vector2 movement_vector;
    private Vector2 old_vector;
    private string spellChain;
    private int spellIndex;
    public Image iconFire;
    public FireBall fireball;
    private Vector2 prevDir;

    //tood canvas UI


    protected void Start()
    {
        //Get a component reference to the Player's animator component
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        spellIndex = -1;
        iconFire.enabled = false;
    }

    private void Update()
    {
        movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        if (Input.GetMouseButtonDown(1))
        {
            old_vector = new Vector2(-2, -2);
            spellChain = "";
        }
        else if (Input.GetMouseButton(1))
        {
            animator.SetBool("Spell", true);
            animator.SetFloat("input_x", movement_vector.x);
            animator.SetFloat("input_y", movement_vector.y);

            if (movement_vector != old_vector)
            {

                if (movement_vector == new Vector2(1, 0))
                {
                    spellChain += "R";
                }
                else if (movement_vector == new Vector2(-1, 0))
                {
                    spellChain += "L";
                }
                else if (movement_vector == new Vector2(0, 1))
                {
                    spellChain += "U";
                }
                else if (movement_vector == new Vector2(0, -1))
                {
                    spellChain += "D";
                }
                old_vector = movement_vector;
            }
            Debug.Log("spell " + spellChain);
            //todo limit chain size



            movement_vector = Vector2.zero;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            spellCheck(spellChain);
        }
        else
        {
            animator.SetBool("Spell", false);
            if (movement_vector != Vector2.zero)
            {
                animator.SetBool("isWalking", true);
                animator.SetFloat("input_x", movement_vector.x);
                animator.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

            prevDir = (movement_vector.Equals(Vector2.zero)) ? prevDir : movement_vector;

            if (Input.GetMouseButtonDown(0))
            {
                switch (spellIndex)
                {
                    case 0:
                        Debug.Log("Fireball!");
                        //create tmp variable to call its function
                        FireBall tmp = (FireBall)Instantiate(fireball, new Vector3(transform.position.x + 0.8f + prevDir.x*1.5f, transform.position.y+1+ prevDir.y*1.5f, transform.position.z), Quaternion.identity);
                        //send normalized vector to our created fireball
                        tmp.Dir(prevDir.normalized);
                        
                        break;
                    case 1:
                        Debug.Log("Case 2");
                        break;
                    default:
                        Debug.Log("No active spell");
                        break;
                }
            }
        }


        rbody.MovePosition(rbody.position + movement_vector / 10);    
    }


    private void spellCheck(string s)
    {
        string spellFire = "ULR";
        string spellUh = "LDU";
        if(String.Equals(s, spellFire))
        {
            Debug.Log("Spell Fire");
            iconFire.enabled = true;
            spellIndex = 0;
        }
        else if (String.Equals(s, spellUh))
        {
            Debug.Log("Spell Uh");
            spellIndex = 1;
        }
        else
        {
            spellIndex = -1;
            iconFire.enabled = false;
        }
    }
}