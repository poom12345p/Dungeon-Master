using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eplorer_spwan : MonoBehaviour {
        public GameObject explorer;

	// Use this for initialization
	void Start () {
        StartCoroutine("spawn_explorer");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator spawn_explorer()
    {
        while(true)
        {
         
            yield return new WaitForSeconds(5f);
            if (!Dungeon_data.stop && Dungeon_data.explorer_in < 10)
            {
                Dungeon_data.explorer_in++;
                Instantiate(explorer, door_scp.real_door.transform.position, Quaternion.identity);
            }
                
        }
        
    }
}
