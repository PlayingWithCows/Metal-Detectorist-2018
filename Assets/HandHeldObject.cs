using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeldObject : MonoBehaviour {

    public int itemID = 0;
    public string itemName = "empty";
    public bool isActive = true;
    public Camera mainCamera;
    private int layerMask;

    public LineRenderer lineRenderer;
    public Vector3 pointPosition;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }
    // Update is called once per frame
    void Update () {
        GetPointPosition();
	}

    private void GetPointPosition()
    {
        
        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.distance >= 5f)
            {
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
                lineRenderer.enabled = false;
                return;
            }
            else
            {
                pointPosition = hit.point;
                Debug.Log(hit.collider.name);
                DrawLine();
            }
        }
 

      
    }

    private void DrawLine()
    {
        

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pointPosition);
        lineRenderer.enabled = true;
    }
}
