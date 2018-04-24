using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDeformer : MonoBehaviour {

    public HandHeldObject handHeldObject;
    public float strength;
    public TerrainMover terrainMover;
    public int size=1;

    public Vector3 smallScale, medScale, bigScale;
    // Use this for initialization
    void Start () {
        UpdateBallScale(1);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && handHeldObject.interactionSphereRenderer.enabled)
        {
            terrainMover.MoveTerrain(handHeldObject.pointPosition, strength, size);
        }
        if (Input.GetButton("Fire2") && handHeldObject.interactionSphereRenderer.enabled)
        {
            terrainMover.MoveTerrain(handHeldObject.pointPosition, -strength, size);
        }

        if (Input.GetKeyDown(KeyCode.E)) {

            size= Mathf.Clamp(size+1, 1, 3);
            UpdateBallScale(size);
       
        }
        else if (Input.GetKeyDown(KeyCode.Q)) {

            size = Mathf.Clamp(size-1, 1, 3);
            UpdateBallScale(size);
           
        }
        
    }

    private void UpdateBallScale(int newBallsize)
    {
        if(newBallsize == 1)
            handHeldObject.interactionSphereRenderer.gameObject.transform.localScale = smallScale;
        if (newBallsize == 2)
            handHeldObject.interactionSphereRenderer.gameObject.transform.localScale = medScale;
        if (newBallsize == 3)
            handHeldObject.interactionSphereRenderer.gameObject.transform.localScale = bigScale;
    }
}
