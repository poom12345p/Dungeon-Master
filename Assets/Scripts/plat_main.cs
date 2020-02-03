using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat_main : MonoBehaviour
{
    public bool active = false;
    public bool have_core = false, have_door = false,IsUse = false;
    public static bool nav_Bulid = false, mouse_on = true;
    public Sprite floor, wall, curve, rock;
    public GameObject top, topL, topR, L, R, botL, bot, botR, checkbox, crop, plat;
    public GameObject path_T, path_TL, path_TR, path_L, path_M, path_R, path_B, path_BL, path_BR;
    GameObject temp_crop, temp_core;

    public Texture2D Trageted;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool cnT, cnL, cnR, cnB, cnTL, cnTR, cnBL, cnBR;
    // Use this for initialization

    void Start()
    {
        setwall();
        setpath();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseEnter()
    {
       
        Dungeon_data.pos_plat_mouseon = new Vector3(transform.position.x, 0.5f, transform.position.z);
        Dungeon_data.point_plat = this.transform;
        if(active)
        {
            object_manager.Is_can_place = true;
        }
        else
        {
            object_manager.Is_can_place = false;
        }
        //Debug.Log("mouse_pos" + Dungeon_data.pos_plat_mouseon.x + "/" + Dungeon_data.pos_plat_mouseon.y);
        if (mouse_on)
        {
            hotSpot = new Vector2(Trageted.width * 0.5f, Trageted.height * 0.5f);
            Cursor.SetCursor(Trageted, hotSpot, cursorMode);
            temp_crop = Instantiate(crop, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            nav_Bulid = true;

            if (core_scp.mouse_onCore && active)
            {
                core_scp.tempcore_goto(transform.position);
            }
            else if (door_scp.mouse_on_door && active)
            {
                door_scp.tempdoor_goto(transform.position);
            }
        }
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        Destroy(temp_crop, 0.0f);


    }
    void activate_plat()
    {
        Dungeon_data.all_Plat++;
        top.SetActive(true);
        topL.SetActive(true);
        topR.SetActive(true);
        L.SetActive(true);
        R.SetActive(true);
        botL.SetActive(true);
        bot.SetActive(true);
        botR.SetActive(true);
        plat.GetComponent<SpriteRenderer>().sprite = floor;
        //dun_valuechange
        Dungeon_data.soul -= Dungeon_data.all_Plat * 2;
        Dungeon_data.interest += 1;

    }
    void de_activate()
    {
        Dungeon_data.all_Plat--;
        top.SetActive(false);
        topL.SetActive(false);
        topR.SetActive(false);
        L.SetActive(false);
        R.SetActive(false);
        botL.SetActive(false);
        bot.SetActive(false);
        botR.SetActive(false);
        plat.GetComponent<SpriteRenderer>().sprite = rock;
        Dungeon_data.interest -= 1;


    }
    void OnMouseDown()
    {
        if (mouse_on)
        {
            if (object_manager.on_hold)
            {

            }
            else
            {
                if (!active && Dungeon_data.mode == 1)
                {
                    activate_plat();
                    GameObject chb = Instantiate(checkbox, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    Destroy(chb, 0.5f);
                    active = true;
                }
                else if (active && Dungeon_data.mode == 2 && Dungeon_data.all_Plat > 1)
                {
                    de_activate();
                    GameObject chb = Instantiate(checkbox, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    Destroy(chb, 0.5f);
                    active = false;

                }
                else if (active && Dungeon_data.mode == 3)
                {
                    if (core_scp.mouse_onCore && !have_door)
                    {
                        core_scp.setcore(transform.gameObject);
                        have_core = true;
                        Debug.Log("COrePLACED");
                    }
                    else if (door_scp.mouse_on_door && !have_core)
                    {
                        bool face_check = false;
                        if ((door_scp.facing == 0 && !cnB) || (door_scp.facing == 1 && !cnL)
                            || (door_scp.facing == 2 && !cnT) || (door_scp.facing == 3 && !cnR))
                        {
                            face_check = true;
                        }

                        if (face_check)
                        {
                            door_scp.setdoor(transform.gameObject);
                            have_door = true;
                            Debug.Log("DOORPLACED");

                        }

                    }
                    else if (!door_scp.mouse_on_door && !core_scp.mouse_onCore)
                    {
                        if (have_core)
                        {
                            core_scp.mouse_onCore = true;
                            have_core = false;
                        }
                        else if (have_door)
                        {
                            door_scp.mouse_on_door = true;
                            have_door = false;
                        }
                    }
                }

            }

        }
    }

    private void setwall()
    {
        //phase 1to1
        if (active)
        {
            top.SetActive(true);
            topL.SetActive(true);
            topR.SetActive(true);
            L.SetActive(true);
            R.SetActive(true);
            botL.SetActive(true);
            bot.SetActive(true);
            botR.SetActive(true);

            //phase 1to3
            if (cnTL && cnT && cnL)
            {
                topL.SetActive(false); ;
            }
            else
            {
                topL.SetActive(true);
                topL.GetComponent<SpriteRenderer>().sprite = curve;
                topL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 90.0f));
            }

            if (cnTR && cnT && cnR)
            {
                topR.SetActive(false);
            }
            else
            {
                topR.SetActive(true);
                topR.GetComponent<SpriteRenderer>().sprite = curve;
                topR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));
            }

            if (cnBL && cnB && cnL)
            {
                botL.SetActive(false);
            }
            else
            {
                botL.SetActive(true);
                botL.GetComponent<SpriteRenderer>().sprite = curve;
                botL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 180.0f));
            }

            if (cnBR && cnB && cnR)
            {
                botR.SetActive(false);

            }
            else
            {
                botR.SetActive(true);
                botR.GetComponent<SpriteRenderer>().sprite = curve;
                botR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, -90.0f));
            }
        }

        if (cnR)
        {
            R.SetActive(false);
            topR.GetComponent<SpriteRenderer>().sprite = wall;
            topR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));
            botR.GetComponent<SpriteRenderer>().sprite = wall;
            botR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 180.0f));

        }


        if (cnL)
        {
            L.SetActive(false);
            topL.GetComponent<SpriteRenderer>().sprite = wall;
            topL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));
            botL.GetComponent<SpriteRenderer>().sprite = wall;
            botL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 180.0f));

        }


        if (cnB)
        {
            bot.SetActive(false);
            botR.GetComponent<SpriteRenderer>().sprite = wall;
            botR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, -90.0f));
            botL.GetComponent<SpriteRenderer>().sprite = wall;
            botL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 90.0f));

        }
        if (cnT)
        {
            top.SetActive(false);
            topR.GetComponent<SpriteRenderer>().sprite = wall;
            topR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, -90.0f));
            topL.GetComponent<SpriteRenderer>().sprite = wall;
            topL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 90.0f));
        }
        //phase 1to 2
        if (cnT && cnL)
        {
            topL.GetComponent<SpriteRenderer>().sprite = curve;
            topL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, -90.0f));
        }
        if (cnT && cnR)
        {
            topR.GetComponent<SpriteRenderer>().sprite = curve;
            topR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 180.0f));
        }
        if (cnB && cnL)
        {
            botL.GetComponent<SpriteRenderer>().sprite = curve;
            botL.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f));

        }
        if (cnB && cnR)
        {
            botR.GetComponent<SpriteRenderer>().sprite = curve;
            botR.transform.rotation = Quaternion.Euler(new Vector3(90.0f, 0.0f, 90.0f));


        }



    }

    void setpath()
    {
        if (active)
        {
            path_M.SetActive(true);

            if (cnR) path_R.SetActive(true);
            else path_R.SetActive(false);

            if (cnL) path_L.SetActive(true);
            else path_L.SetActive(false);

            if (cnB) path_B.SetActive(true);
            else path_B.SetActive(false);

            if (cnT) path_T.SetActive(true);
            else path_T.SetActive(false);


            if (cnTL && cnT && cnL) path_TL.SetActive(true);
            else path_TL.SetActive(false);

            if (cnTR && cnT && cnR) path_TR.SetActive(true);
            else path_TR.SetActive(false);

            if (cnBL && cnB && cnL) path_BL.SetActive(true);
            else path_BL.SetActive(false);

            if (cnBR && cnB && cnR) path_BR.SetActive(true);
            else path_BR.SetActive(false);

        }
        else
        {
            path_M.SetActive(false);
            path_R.SetActive(false);
            path_L.SetActive(false);
            path_B.SetActive(false);
            path_T.SetActive(false);
            path_TL.SetActive(false);
            path_TR.SetActive(false);
            path_BL.SetActive(false);
            path_BR.SetActive(false);
        }


    }
    void OnTriggerExit(Collider col)
    {

        if (col.tag == "core")
        {
            have_core = false;
        }
        else if (col.tag == "door")
        {
            have_door = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // Debug.Log("Hit");
        if (Dungeon_data.mode == 1)
        {
            switch (col.tag)
            {
                case "checkTop":
                    cnB = true;
                    break;
                case "checkTopL":
                    cnBR = true;
                    break;
                case "checkTopR":
                    cnBL = true;
                    break;
                case "checkL":
                    cnR = true;
                    break;
                case "checkR":
                    cnL = true;
                    break;
                case "checkBot":
                    cnT = true;
                    break;
                case "checkBotL":
                    cnTR = true;
                    break;
                case "checkBotR":
                    cnTL = true;
                    break;

            }

        }
        else if (Dungeon_data.mode == 2)
        {
            switch (col.tag)
            {
                case "checkTop":
                    cnB = false;
                    break;
                case "checkTopL":
                    cnBR = false;
                    break;
                case "checkTopR":
                    cnBL = false;
                    break;
                case "checkL":
                    cnR = false;
                    break;
                case "checkR":
                    cnL = false;
                    break;
                case "checkBot":
                    cnT = false;
                    break;
                case "checkBotL":
                    cnTR = false;
                    break;
                case "checkBotR":
                    cnTL = false;
                    break;

            }
        }
        if (Dungeon_data.mode == 1 || Dungeon_data.mode == 2)
        {
            setwall();
            setpath();
        }
        if (col.tag == "core")
        {
            have_core = true;
        }
        else if (col.tag == "door")
        {
            have_door = true;
        }


    }
}
