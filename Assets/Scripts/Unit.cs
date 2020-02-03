using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour {
    public NavMeshAgent agent;
    public int atk, def, hp, max_hp;
    public GameObject damage_box,temp_damage_box,target;
    public float atk_speed = 0,angle_to_target;
    public bool isAttack,isActtacking,isMove;
    public float viewRad, viewAngle;
    public char facing;

    //public string enemy_tag;
    public LayerMask targetMask;
    public List<Transform> onRange_target = new List<Transform>();
    // Use this for initialization
    void Start () {

        StartCoroutine("fow_delay", 0.2f);
        isAttack = false;
        isActtacking = false;
        target = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(agent.desiredVelocity.x > 0 || agent.desiredVelocity.z > 0 )
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        if(target!=null && Vector3.Distance(transform.position,target.transform.position) > viewRad)
        {
            target = null;
        }

        check_facing();
        
        if (isAttack && !isActtacking)
        {
            StartCoroutine("attck_action", atk_speed);
            isActtacking = true;
        }
        else if(!isAttack)
        {
            StopCoroutine("attck_action");
            isActtacking = false;
        }

        if (onRange_target.Count > 0 && (target == null||target.name =="core"))
        {
            target = onRange_target[Random.Range(0, onRange_target.Count - 1)].gameObject;
        }

        if(target != null && Vector3.Distance(transform.position,target.transform.position) <= 2)
        {
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
    }

 
    IEnumerator fow_delay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            find_visible_object();
        }
    }

    IEnumerator attck_action(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if(!Dungeon_data.stop&& !isMove)
            {
                unit_attack(0);
            }
           

        }
    }
    void find_visible_object()
    {
        onRange_target.Clear();
        Collider[] target_in_rad = Physics.OverlapSphere(transform.position, viewRad, targetMask);
        for (int i = 0; i < target_in_rad.Length; i++)
        {
            onRange_target.Add(target_in_rad[i].transform);

        }


    }
    public void damage_takken(int atk)
    {
        hp -= atk;
        if (hp <= 0)
        {
            if (tag == "explorer")
            { 
            Dungeon_data.explorer_in--;
             }
            Destroy(this.gameObject, 0.1f);
        }
    }

    public void unit_attack(int atk_type)
    {
        if(atk_type ==0)
        {
            Vector3 damge_direction = transform.position;
            switch(facing)
            {
                case 'T':
                    damge_direction.z += 0.5f;
                    break;
                case 'D':
                    damge_direction.z -= 0.5f;
                    break;
                case 'R':
                    damge_direction.x += 0.5f;
                    break;
                case 'L':
                    damge_direction.x -= 0.5f;
                    break;
            }
                temp_damage_box = Instantiate(damage_box, damge_direction, Quaternion.Euler(new Vector3(90, 0, 0)));
                temp_damage_box.transform.parent = transform;
                set_damage(temp_damage_box.transform);

        }

    }

    private void OnTriggerEnter(Collider col)
    {
       if(col.tag=="damage")
        {
            foreach(string tar_tag in col.GetComponent<Damage>().target_tag)
            {
                if(tar_tag ==transform.tag)
                {
                   damage_takken(col.GetComponent<Damage>().damage);
                }
            }
        }
       


    }

    void set_damage(Transform dam_box)
    {
        Damage dam = dam_box.GetComponent<Damage>();
        dam.target_tag.Clear();
        switch (transform.tag)
        {
            case "monster":
                dam.target_tag.Add("explorer");
                break;
            case "explorer":
                dam.target_tag.Add("monster");
                dam.target_tag.Add("core");
                break;

        }
        dam.destroy_time = atk_speed / 2;

        dam.damage = atk;
    }
    
    public void check_facing()
    {
       
        if (agent != null)
        {
            angle_to_target = Mathf.Atan2(agent.desiredVelocity.x,agent.desiredVelocity.z)*Mathf.Rad2Deg;
            if (target != null)
          
            if (angle_to_target < -45 && angle_to_target >=-135)
            {
                facing = 'L';
            }
            else if(angle_to_target >=-45 && angle_to_target < 45)
            {
                facing = 'T';
            }
            else if (angle_to_target <135 && angle_to_target >= 45)
            {
                facing = 'R';
            }
            else
            {
                facing = 'D';
            }
        }

    }

}
