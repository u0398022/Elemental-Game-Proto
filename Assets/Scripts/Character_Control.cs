﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Control : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] Transform camera;
    public float speed = 6.0f;
    private float initSpeed;
    int time = 0;
    //public float gravity = 20.0f; not going to use gravity right now

    private Vector3 move = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        initSpeed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Jump")&& time <1)
        {
            Debug.Log("Dash");
            speed *= 4;
            time = 20;
        }
        // Move the controller
        characterController.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero)
            transform.forward = move;
        if (time > 0)
        {
            time--;
            if (time == 0)
            {
                speed = initSpeed;
            }
        }
        


    }
}
