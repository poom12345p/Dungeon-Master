using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explorers : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public string my_class;
    //List<GameObject> mons= new List<GameObject>();
    Unit unit;
    float defalt_speed = 1;

    // Use this for initialization
    void Start()
    {
        unit = transform.GetComponent<Unit>();
        target = core_scp.real_core;
        switch (my_class)
        {
            case "Man":
                unit.atk = 10;
                unit.def = 5;
                unit.max_hp = 100;
                unit.hp = unit.max_hp;
                unit.atk_speed = 1.6f;
                break;

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (unit.onRange_target.Count == 0)
        {
            unit.target = target = core_scp.real_core;
        }
        else
        {
            target = unit.onRange_target[Random.Range(0, unit.onRange_target.Count - 1)].gameObject;
        }

        if (!Dungeon_data.stop)
        {
            agent.speed = defalt_speed;
            if (target != null)
            {
                agent.SetDestination(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
            }
            

        }
        else
            {
                agent.speed = 0;
            }

    }
}
