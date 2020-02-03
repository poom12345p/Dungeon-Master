using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_scp : MonoBehaviour {
    public static bool mouse_on_door = false;
    public GameObject core, checker;
    public static GameObject real_door;
    public static int facing = 0;//0=d,1=l,2=u,3=r
    static Vector3 now_pos;
    public bool open = true;
    // Use this for initialization
    void Start () {
        real_door = this.gameObject;
        now_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (mouse_on_door)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0) // bakcward
            {
                facing++;
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                facing--;
            }
            facing = (4+facing )% 4;
            switch(facing)
            {
                case 0:
                    transform.eulerAngles=new Vector3(90f, 0f,0f);
                    break;
                case 1:
                    transform.eulerAngles = new Vector3(90f, 0f, -90f);
                    break;
                case 2:
                    transform.eulerAngles = new Vector3(90f, 0f, 180f);
                    break;
                case 3:
                    transform.eulerAngles = new Vector3(90f, 0f, 90f);
                    break;

            }
        }
	}

    public static void tempdoor_goto(Vector3 pos)
    {
        real_door.transform.position = new Vector3(pos.x, 2, pos.z);
    }


    public static void setdoor(GameObject palt)
    {
        mouse_on_door = false;
        real_door.transform.position = new Vector3(palt.transform.position.x, 2, palt.transform.position.z);
        now_pos = real_door.transform.position;
    }
    
    public void reset_door()
    {
        mouse_on_door = false;
        real_door.transform.position = now_pos;
    }
        
}
