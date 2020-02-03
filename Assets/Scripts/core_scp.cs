using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class core_scp : MonoBehaviour
{   
    public static bool mouse_onCore = false;
    public GameObject door;
    public static int core_hp = 0,max_core_hp=1000;
    public Text core_hp_text;
    public static GameObject real_core;
    static Vector3 now_pos;
    Explorers colsc;
    Unit unit;
    // Use this for initialization
    void Start()
    {
        unit = transform.GetComponent<Unit>();
        now_pos = transform.position;
        core_hp = max_core_hp;  
        real_core = this.gameObject;
        unit.max_hp = max_core_hp;
        unit.hp= max_core_hp;
        core_hp = max_core_hp;

        //temp_core = Instantiate(_core, real_core.transform.position, Quaternion.Euler(90f, 0f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        core_hp = unit.hp;  
        core_hp_text.text = core_hp.ToString() + "/" + max_core_hp.ToString();
    }
 

    public static void tempcore_goto(Vector3 pos)
    {
        real_core.transform.position = new Vector3(pos.x, 2, pos.z);
    }


    public static void setcore(GameObject palt)
    {
        mouse_onCore = false;
        real_core.transform.position = new Vector3(palt.transform.position.x, 2, palt.transform.position.z);
        now_pos = real_core.transform.position;
    }
    public void reset_core()
    {
        mouse_onCore = false;
        real_core.transform.position = now_pos;
    }

    public void damage_takken(int atk)
    {
        core_hp -= atk;
        if(core_hp<=0)
        {
            Dungeon_data.stop = true;
        }
    }
}
