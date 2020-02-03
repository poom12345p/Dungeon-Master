using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class core_check : MonoBehaviour
{

    public NavMeshAgent agent;
    public static bool core_place = false, link_on = false, door_place = false;
    public bool switch_d_c = true;//ture=door,flase=core
    public GameObject door;
    bool setOn_door = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("core_place=" + core_place);
        //Debug.Log("door_place=" + door_place);
        Debug.Log("link on =" + link_on);
        if (Dungeon_data.mode == 0)
        {
            if (switch_d_c)
            {
                agent.SetDestination(new Vector3(door.transform.position.x, transform.position.y, door.transform.position.z));
            }
            else
            {
                agent.SetDestination(new Vector3(core_scp.real_core.transform.position.x, transform.position.y, core_scp.real_core.transform.position.z));
            }

        }
        else
        {

            transform.position = new Vector3(door.transform.position.x, transform.position.y, door.transform.position.z);
            agent.SetDestination(new Vector3(door.transform.position.x, transform.position.y, door.transform.position.z));

        }




    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "door")
        {
            door_place = false;
        }



    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "core")
        {
            core_place = true;
            switch_d_c = true;
        }
        else if (col.tag == "door")
        {
            door_place = true;
            if (core_place && door_place)
            {
                link_on = true;
            }
        }

    }
    public void switch_bool_view()
    {
        link_on = false;
        core_place = false;
        switch_d_c = false;
    }

}
