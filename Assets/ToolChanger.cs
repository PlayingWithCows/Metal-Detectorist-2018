using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChanger : MonoBehaviour {

    public int selectedTool=0;
    public List<HandHeldObject> tools = new List<HandHeldObject>();

	// Use this for initialization
	void Start () {
        HandHeldObject[] toolsScripts = GetComponentsInChildren<HandHeldObject>();
      
        foreach (HandHeldObject script in toolsScripts)
        {
            tools.Add(script);
        }
        tools.Sort((a, b) => (a.itemID.CompareTo(b.itemID)));


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            selectedTool = Mathf.Clamp(selectedTool + 1, 0, 1);
            UpdateTool(selectedTool);
            Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {

            selectedTool = Mathf.Clamp(selectedTool - 1, 0, 1);
            UpdateTool(selectedTool);
            Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    private void UpdateTool(int newTool)
    {
        foreach (HandHeldObject tool in tools)
        {
            tool.gameObject.SetActive(false);
        }
        tools[newTool].gameObject.SetActive(true);
    }
}
