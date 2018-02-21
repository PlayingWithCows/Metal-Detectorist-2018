using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour {

    public bool canRotate = true;
    public float maxUpDownAngle = 80;
    public float currentAngle;
    public float rotateSpeed;

	void Update () {

     
        RotateObject(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    }

    void RotateObject(float mouseX, float mouseY)
    {
        gameObject.transform.Rotate(Vector3.up, mouseX * Time.deltaTime * rotateSpeed, Space.World);
        
        if ((Mathf.Abs(currentAngle) + mouseY) <= maxUpDownAngle)
        {
            currentAngle = currentAngle + mouseY;
            gameObject.transform.Rotate(Vector3.left, mouseY * Time.deltaTime * rotateSpeed);
        }
    }
}
