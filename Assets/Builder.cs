using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

    public bool canBuild;
    public List<Transform> prefabs = new List<Transform>();
    public float buildCooldown = 1;

    private Transform buildObjectsGroup;
    private HandHeldObject device;
    private Transform objectToBuild;
    private float timeLastBuilt;
    
	// Use this for initialization
	void Start () {
        timeLastBuilt = Time.time;
        buildObjectsGroup = GameObject.Find("BuildObjects").transform;
        objectToBuild = prefabs[0];
        device = gameObject.GetComponent<HandHeldObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (device.leftClicking) { Build(); }
    }

    public void Build()
    {
        if (timeLastBuilt + buildCooldown <= Time.time)
        {

            Instantiate(objectToBuild, device.pointPosition, Quaternion.identity, buildObjectsGroup);

            timeLastBuilt = Time.time;

        }
    }
}
