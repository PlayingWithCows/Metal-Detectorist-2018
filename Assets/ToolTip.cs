using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{

    public Transform toolTippedObject;
    public TextMesh titleMesh, descriptionMesh;

    private bool setupComplete = false;
    private RectTransform rt;
    private Vector3 toolTipPosition;
    private float distanceFromObject;
    // Update is called once per frame


    void Update()
    {
        if (setupComplete)
            UpdatePositionAndScale();
    }

    private void UpdatePositionAndScale()
    {
        
        toolTipPosition = Vector3.MoveTowards(toolTippedObject.position, Camera.main.transform.position, distanceFromObject);
        transform.position = toolTipPosition;
        transform.LookAt(Camera.main.transform);
    }

    //private float CalculateScale(float scale, float inputMin, float inputMax, float outputMin, float outputMax)
    //{

    //    if (scale > inputMax)
    //    {

    //        scale = inputMax;
    //    }

    //    if (scale < inputMin)
    //    {
    //        scale = inputMin;
    //    }

    //    float position = (scale - inputMin) / (inputMax - inputMin);

    //    float relativeValue = position * (outputMax - outputMin) + outputMin;

    //    return relativeValue;
    //}

    private void Start()
    {
        


    }

    public void FillToolTip(Transform tippedObject, string itemName, string description, float objectSize)
    {
    //itemNameText = 
    //descriptionText = 
       
        toolTippedObject = tippedObject;
        titleMesh.text = itemName;
        descriptionMesh.text = description;
        distanceFromObject = objectSize;
        setupComplete = true;
    }
}
