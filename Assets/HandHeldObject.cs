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

    public  bool leftClicking = false;
    public  bool rightClicking = false;
    public LineRenderer lineRenderer;
    public Vector3 pointPosition;
    public MeshRenderer interactionSphereRenderer;
    public SphereCollider interactionSphereCollider;
    public bool useSphere;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        interactionSphereRenderer.enabled = false;
        interactionSphereCollider.enabled = false;

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
                interactionSphereRenderer.transform.position = Vector3.zero;
                interactionSphereRenderer.enabled = false;
                interactionSphereCollider.enabled = false;
                lineRenderer.enabled = false;
                return;
            }
            else
            {
                pointPosition = hit.point;
                DrawLine();

                if (hit.collider.gameObject.GetComponent<InteractObject>() != null)
                {
                    hit.collider.gameObject.GetComponent<InteractObject>().IsLookedAt();
                }

                if (Input.GetButtonDown("Fire1"))
                {
                    if (hit.collider.gameObject.GetComponent<InteractObject>() != null)
                    {
                        hit.collider.gameObject.GetComponent<InteractObject>().IsLeftClicked();
                    }
                    leftClicking = true;
                }

                if (Input.GetButtonDown("Fire2"))
                {
                    if (hit.collider.gameObject.GetComponent<InteractObject>() != null)
                    {
                        hit.collider.gameObject.GetComponent<InteractObject>().IsRightClicked();
                    }
                    rightClicking = true;
                }
                if (Input.GetButtonUp("Fire1")) { leftClicking = false;  }
                if (Input.GetButtonUp("Fire2")) { rightClicking = false;  }


            }
            }
        }
 

      
    

    private void DrawLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, pointPosition);
        interactionSphereRenderer.transform.position = pointPosition;
        if (useSphere)
        {
            interactionSphereRenderer.enabled = true;
            interactionSphereCollider.enabled = true;
        }
        else
        {
               interactionSphereRenderer.enabled = false;
            interactionSphereCollider.enabled = false;
        }
            lineRenderer.enabled = true;
    }
}
