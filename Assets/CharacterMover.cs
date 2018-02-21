using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {

    private CharacterController cController;
    public HeadMovement headMovement;
    public bool canMove = true;
    public float moveSpeedFwd, moveSpeedBwd, moveSpeedStrafe;
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

        if (canMove)
        {
          
            TurnPlayer();    
            
            MovePlayer(walkForwardBackward, strafeLeftRight);


        }



    }

    private void TurnPlayer()
    {
        Quaternion rot = headMovement.transform.localRotation;
       // gameObject.transform.Rotate(0, rot.y, 0, Space.World);
       // headMovement.gameObject.transform.Rotate(0,-rot,0, Space.World);
        Debug.Log(rot);
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

        Vector3 moveDirection = new Vector3(moveVectorFwdBwd, 0, -strafeLeftRight*moveSpeedStrafe);
        moveDirection = transform.TransformDirection(moveDirection);
        cController.Move(moveDirection*Time.deltaTime);
    }


}
