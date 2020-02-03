using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {
    public  List<string> abandon_tag = new List<string>();
    public bool isHolding;
	// Use this for initialization
	void Start () {
        abandon_tag.Add(this.transform.tag);
        if(this.tag !="spwan")
        {
            abandon_tag.Add("door");
            abandon_tag.Add("core");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        check_tag(other);

    }

    private void OnTriggerExit(Collider other)
    {
        if (!object_manager.Is_can_place && isHolding)
        {
            foreach (string aban_t in abandon_tag)
            {
                if (aban_t == other.tag)
                {
                    object_manager.Is_can_place = true;
                    break;
                }
            }
        }

    }


    private void OnTriggerStay(Collider other)
    {
        check_tag(other);

    }
    void check_tag(Collider other)
    {
        if(object_manager.Is_can_place && isHolding)
        {
            foreach (string aban_t in abandon_tag)
            {
                if (aban_t == other.tag)
                {
                    object_manager.Is_can_place = false;
                    break;
                }
            }
            Debug.Log("isCanPalce=" + object_manager.Is_can_place);
        }
       
    }

}
