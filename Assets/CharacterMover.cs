using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {

    private CharacterController cController;
    public HeadMovement headMovement;
    public bool canMove = true;
    public float gravity;
    public float jumpSpeed;
    public float moveSpeedFwd, moveSpeedBwd, moveSpeedStrafe;

    private float verticalVelocity=0;
    
    private Vector3 moveDirection = Vector3.zero;


    // Use this for initialization
    void Start () {
        cController = gameObject.GetComponent<CharacterController>();
        headMovement = gameObject.transform.GetComponentInChildren<HeadMovement>();
        

    }
	
	// Update is called once per frame
	void Update () {
        GetInputs();
  
    }

    private void GetInputs()
    {
        float strafeLeftRight = Input.GetAxis("Horizontal");
    
        float walkForwardBackward = Input.GetAxis("Vertical");
        //Debug.Log(walkForwardBackward);
        if (canMove)
        {
    
            
            MovePlayer(walkForwardBackward, strafeLeftRight);


        }



    }



    void MovePlayer(float walkForwardBackward, float strafeLeftRight)
    {
        float moveVectorFwdBwd = 0;
        if (walkForwardBackward <= 0)
        {
            moveVectorFwdBwd = walkForwardBackward* moveSpeedBwd;
        }if(walkForwardBackward >= 0)
        {
            moveVectorFwdBwd = walkForwardBackward* moveSpeedFwd;
        }
        verticalVelocity += -gravity * Time.deltaTime;
     
        if (cController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
                verticalVelocity = jumpSpeed;
        }
        moveDirection = new Vector3(strafeLeftRight * moveSpeedStrafe, verticalVelocity, moveVectorFwdBwd);
        moveDirection = transform.TransformDirection(moveDirection);
        //Debug.Log(moveDirection);
        cController.Move(moveDirection*Time.deltaTime);
    }


}
