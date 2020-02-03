using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mark : MonoBehaviour {
    public NavMeshAgent agent;
    public Vector3 mypost,par_pos;
    public Vector3 next;
    public double dx, dz;
    // Use this for initialization
    void Start() {
        agent = transform.parent.transform.GetComponent<NavMeshAgent>();
    }

	// Update is called once per frame
	void Update () {
        par_pos = transform.parent.transform.position;
        transform.position = new Vector3(par_pos.x+(agent.desiredVelocity.x),transform.position.y, par_pos.z+ (agent.desiredVelocity.z));
        mypost = transform.position;
        next = agent.desiredVelocity;
        dx = par_pos.x - agent.nextPosition.x;
        dz = par_pos.z - agent.nextPosition.z;
  
	}
}
