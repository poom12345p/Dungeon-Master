using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

    private Animator ani;
    public GameObject damage_box,temp_damage;
    public bool isReady=true, isActive, isCooldown;
    public float cool_time = 5f;
    public int atk =10;
    building Build;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
        Build = transform.GetComponent<building>();
        isReady = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {  
        if(col.tag == "explorer" && !Build.isHolding && isReady)
        {

            ani.SetTrigger("ac");
            set_damage();
            isReady = false;
            StartCoroutine("coolDown");
        }
    }

    IEnumerator coolDown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1);
        ani.SetTrigger("de");
        yield return new WaitForSeconds(cool_time);
        isReady = true;
        isCooldown = false;
    }
    void set_damage()
    {
        temp_damage = Instantiate(damage_box, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        temp_damage.transform.parent = transform;
        Damage dam = temp_damage.GetComponent<Damage>();
        dam.target_tag.Clear();
        dam.target_tag.Add("explorer");
        dam.destroy_time =1;
        dam.damage = atk;
    }
}
