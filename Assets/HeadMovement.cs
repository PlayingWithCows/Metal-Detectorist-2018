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
        currentAngle -= mouseY * rotateSpeed;
                   
        currentAngle = Mathf.Clamp(currentAngle, -maxUpDownAngle, maxUpDownAngle);

        gameObject.transform.localRotation = Quaternion.Euler(currentAngle, gameObject.transform.localRotation.eulerAngles.y, gameObject.transform.localRotation.eulerAngles.z);


        gameObject.transform.parent.transform.Rotate(Vector3.up, mouseX * rotateSpeed);

        

    }
}
