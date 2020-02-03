using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mouseOnGUI : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseEnter()
    {
        plat_main.mouse_on = false;
        Debug.Log("off");
    }

    public void OnMouseExit()
    {
        plat_main.mouse_on = true;
        Debug.Log("on");

    }
}
