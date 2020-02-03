using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butt_controll : MonoBehaviour {
    public Text t_make, t_des, t_view, t_mang, t_spawn, t_tarp;
    public GameObject[] butt_build = new GameObject[2];
	// Use this for initialization
	void Start () {
        t_make.color = Color.black;
        t_des.color = Color.black;
        t_view.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Butt_click(Button butt)
    {
        if (butt.name == "Button_view")
            Dungeon_data.mode = 0;
        else if (butt.name == "Button_make")
            Dungeon_data.mode = 1;
        else if (butt.name == "Button_des")
            Dungeon_data.mode = 2;
        else if (butt.name == "Button_manage")
            Dungeon_data.mode = 3;


        if (Dungeon_data.mode == 0) t_view.color = Color.red;
        else t_view.color = Color.black;

        if (Dungeon_data.mode ==1) t_make.color = Color.red;
        else t_make.color = Color.black;

        if (Dungeon_data.mode == 2) t_des.color = Color.red;
        else t_des.color = Color.black;

        if (Dungeon_data.mode == 3) t_mang.color = Color.red;
        else t_mang.color = Color.black;
    }

    public void active_build_butt()
    {
        if(Dungeon_data.mode == 1)
        {
            for(int i=0;i<butt_build.Length;i++)
            {
                butt_build[i].SetActive(true);
            }
            
        }
        else
        {
            for (int i = 0; i < butt_build.Length; i++)
            {
                butt_build[i].SetActive(false);
            }
        }
    }
}
