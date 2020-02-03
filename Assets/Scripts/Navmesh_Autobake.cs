using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh_Autobake : MonoBehaviour {

    public NavMeshSurface[] surfaces;

	// Use this for initialization
	void Start () {
		for(int i=0;i< surfaces.Length;i++)
        {
            surfaces[i].BuildNavMesh();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (plat_main.nav_Bulid)
        {
            baker_Nav();
            plat_main.nav_Bulid = false;
        }
	}
    public void baker_Nav()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}
