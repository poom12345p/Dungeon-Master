using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour
{
    public NavMeshAgent agent;
    public string mons_type;
    bool stopwalk = false, attack = false;
    public bool isOnObj = false,isTargetout=false,isRePath=false,isFixPos=false;
    float defalt_speed = 1f;
    public GameObject target;
    public Vector3 random_des, spwan_center;
    public float next_move = 0;
    Unit unit;
    // Use this for initialization
    void Start()
    {
        unit = transform.GetComponent<Unit>();
        spwan_center = transform.position;
        switch (mons_type)
        {
            case "Slime":
                unit.atk = 5;
                unit.def = 1;
                unit.max_hp = 50;
                unit.hp = unit.max_hp;
                unit.atk_speed = 2f;
                break;

        }
        random_des = new Vector3(spwan_center.x + Random.Range(-4.8f, 4.8f), transform.position.y, spwan_center.z + Random.Range(-4.8f, 4.8f));
        StartCoroutine("random_destination", 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = unit.target;

        if(unit.isActtacking && !unit.isMove && !isOnObj && target !=null)
        {
            isFixPos = true;
        }

        if(target == null)
        {
            isFixPos = false;
        }

        

        if (!Dungeon_data.stop)
        {
            agent.speed = defalt_speed;
            if (target != null&& !isTargetout)
            {
                if(!isOnObj || isFixPos)
                {
                    agent.SetDestination(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                }
                else
                {
                    if(!isRePath)
                    {
                        agent.SetDestination(new Vector3(spwan_center.x + Random.Range(-4.8f, 4.8f), transform.position.y, spwan_center.z + Random.Range(-4.8f, 4.8f)));
                        isRePath = true;
                    }
                    else if(!unit.isMove)
                    {
                        isRePath = false;
                    }
                }


                if (Vector3.Distance(spwan_center, target.transform.position) >= 5f)
                {
                    isTargetout = true;
                }
            }
            else
            {
                agent.SetDestination(random_des);
            }
        }
        else
        {
            agent.speed = 0;
        }

    }


    IEnumerator random_destination(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            random_des = new Vector3(spwan_center.x + Random.Range(-4.8f, 4.8f), transform.position.y, spwan_center.z + Random.Range(-4.8f, 4.8f));
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (!isOnObj)
        {
            switch (col.tag)
            {
                case "monster":
              
                    isOnObj = true;
                    break;

            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
            switch (col.tag)
            {
                case "monster":
                    isOnObj = true;
                    break;

            }
    }

    private void OnTriggerExit(Collider col)
    {
        switch (col.tag)
        {
            case "monster":
                isOnObj = false;
                break;

        }
    }
}
