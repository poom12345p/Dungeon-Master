using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    object_manager obj_man;
    public GameObject[] monster = new GameObject[1];
    int monster_index=0;
    bool IsPlace = false;
    int mons_count = 0,max_mons=5;
    float rate = 1.0f;
    building Build;

    // Use this for initialization
    void Start () {
        StartCoroutine("spawn_mons", rate);
        Build = transform.GetComponent<building>();
        //obj_man = new object_manager();
    }
	
	// Update is called once per frame
	void Update () {
        
        //obj_man.set_pos_obj(this.transform);
	}
  

    void OnTriggerExit(Collider col)
    {
        
        if (col.tag == "monster")
        {
            mons_count--;
        }
    }

   IEnumerator spawn_mons(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if(mons_count < max_mons && !Build.isHolding && !Dungeon_data.stop)
            {
                Instantiate(monster[monster_index], transform.position, Quaternion.identity);
                mons_count++;
            }
            
        }
        
    }

   
}
