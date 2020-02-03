using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dungeon_data : MonoBehaviour{
    public static bool stop = false;
    public static Vector3 pos_plat_mouseon;
    public static int mode = 0, explorer_in =0;//0 viwe, 1 make,2 des,3 manage
    public static string holding_obj;
    public static int interest = 0,soul = 0;
    public float floor_pos_y =0 ;
    public static int all_Floor = 1, all_Plat = 0,all_explorer=0;
    public static int num_Floor = 1;
    public GameObject plat;
    public static Transform point_plat;
    public Text soul_text;
    public static float max_X_pos = 0, max_Y_pos = 0;
    float next_sec = 1f,explorer_spawn_rate=10f;
    // Use this for initialization
    void Start()
    {
        soul = 5000;
        all_Plat+=2;
        max_X_pos += 7.2f;
        max_Y_pos += 7.2f;
        /*Instantiate(plat, new Vector3(0.0f,0.0f,0.0f), Quaternion.Euler(new Vector3(90, 0, 0)));*/
        spawn_plat(5);
        //spawn_explorer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time >= next_sec)
        {
                soul = cal_soul_persec();
                soul_text.text = soul.ToString();
            
            next_sec = Time.time + 1f;
        }

       // Debug.Log("mode=" + mode);

    }


    void spawn_plat(int j)
    {
        for (int k = 0; k < j; k++)
        {
            max_X_pos += 3.6f;
            max_Y_pos += 3.6f;
            for (float i = 0; i <= max_Y_pos; i += 3.6f)
            {
                Instantiate(plat, new Vector3(max_X_pos,floor_pos_y, i), Quaternion.Euler(new Vector3(90, 0, 0)));
                Instantiate(plat, new Vector3(-max_X_pos, floor_pos_y, i), Quaternion.Euler(new Vector3(90, 0, 0)));

            }
            for (float i = max_X_pos - 3.6f; i >= -max_X_pos + 3.59f; i -= 3.6f)
            {
                Instantiate(plat, new Vector3(i, floor_pos_y, max_Y_pos), Quaternion.Euler(new Vector3(90, 0, 0)));
            }

        }
    }

    int cal_soul_persec()
    {
        int minus = 0;
        if (!stop)
        {
            minus += all_Plat;
        }
           
        if(soul - minus>0)
        {
            return soul-minus;
        }
        else
        {
            core_scp.core_hp -= all_Plat;

            return 0;
        }
          
    }

    public void stop_dun()
    {

        stop = true;
    }

    public void run_dun()
    {
        
        stop = false;
    }

}
