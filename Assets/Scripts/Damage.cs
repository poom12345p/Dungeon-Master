using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public int damage;
    public List<string> target_tag = new List<string>();
    public float weight, hight,destroy_time;

    Unit unit;


    // Use this for initialization
    void Start () {
      
    }


    // Update is called once per frame
    void Update () {
		  Destroy(this.gameObject, destroy_time);
	}
}
