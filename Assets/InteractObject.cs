using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour {
    public int objectID;
    public string objectName, itemDescription;
    public float rightClickCooldown = 1;
    public float leftClickCooldown = 1;
    public float timeUntilTooltipDisappears = 2;
    public bool isBuilt = true;
    public bool hasToolTip;
    public GameObject toolTipPrefab;
    public Transform toolTipsGroup;
    public float objectSize = 1;

    
    private bool showingTooltip = false;
    private float timeLastClicked;
    private float timeSinceLastLookAt;

    private bool toolTipExists = false;
    private Transform toolTip;

    void Start()
    {
        
        toolTipExists = false;
        toolTipsGroup = GameObject.Find("ToolTipsGroup").transform;
    }

    public void IsLookedAt()
    {
        timeSinceLastLookAt = Time.time;

        if (!showingTooltip && isBuilt && hasToolTip && !toolTipExists)
        {
            //instantiate tooltip UI object at apparent transform, fill it with description. Later update ui element position, size and transparency based on how far it's in the view field of the camera
            Vector3 toolTipPosition = Vector3.MoveTowards(transform.position, Camera.main.transform.position, objectSize);
            toolTip = Instantiate(toolTipPrefab, toolTipPosition, Quaternion.identity, toolTipsGroup).transform;
            toolTip.GetComponent<ToolTip>().FillToolTip(transform, objectName, itemDescription, objectSize);
            showingTooltip = true;
            toolTipExists = true;

        }
        if (!showingTooltip && isBuilt && hasToolTip && toolTipExists)
        {

            toolTip.gameObject.SetActive(true);
            showingTooltip = true;
            toolTipExists = true;

        }

    }

   void Update()
    {
        RemoveToolTip();
    }

    private void RemoveToolTip()
    {

        if(showingTooltip && timeSinceLastLookAt + timeUntilTooltipDisappears <= Time.time)
        {
            toolTip.gameObject.SetActive(false);
            showingTooltip = false;
            toolTipExists = true;
        }
        if(!showingTooltip && timeSinceLastLookAt + 20f <= Time.time)
        {
            Destroy(toolTip.gameObject);
            showingTooltip = false;
            toolTipExists = false;
        }
    }

    public void IsRightClicked()
    {
        if (Time.time >= timeLastClicked + rightClickCooldown)
        {
            Destroy(gameObject);
            Destroy(toolTip.gameObject);
            timeLastClicked = Time.time;
        }
    }

    public void IsLeftClicked()
    {

        if (Time.time >= timeLastClicked + leftClickCooldown)
        {

            timeLastClicked = Time.time;
        }
    }
}
