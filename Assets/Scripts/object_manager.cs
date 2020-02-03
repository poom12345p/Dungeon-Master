using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class object_manager : MonoBehaviour {

    public GameObject spawner, trap;
    public GameObject on_hold_obj;
    public static bool Is_can_place = true;
    public static bool on_hold = false;
    // Use this for initialization
    void Start () {
        		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("IS can palce="+Is_can_place);
        if (on_hold_obj !=null)
        {
            on_hold_obj.transform.position = Dungeon_data.pos_plat_mouseon;
            if(Input.GetKeyDown(KeyCode.Escape)||Dungeon_data.mode !=1)
            {
                Destroy(on_hold_obj, 0.0f);
                on_hold = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if(Is_can_place)
                {
                    on_hold_obj.GetComponent<building>().isHolding = false;
                    on_hold_obj = null;
                    on_hold = false;
                }
               
            }
        }

    }

    public void set_pos_obj(Transform obj)
    {
        obj.transform.position = Dungeon_data.pos_plat_mouseon;
    }

    public void set_holding_obj(Text butt_text)
    {
        if(butt_text.text =="spawn")
        {
            on_hold_obj = Instantiate(spawner, Dungeon_data.pos_plat_mouseon, Quaternion.Euler(new Vector3(90, 0, 0)));
        }

       if (butt_text.text == "Trap")
        {
            on_hold_obj = Instantiate(trap, Dungeon_data.pos_plat_mouseon, Quaternion.Euler(new Vector3(90, 0, 0)));
        }
        on_hold = true;
        on_hold_obj.GetComponent<building>().isHolding = true;
    }
   
}
