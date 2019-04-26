using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRState : MonoBehaviour
{
    public GameObject robbers;
    public GameObject cops;

    public enum State
    {
        RUNAWAY,
        CHASE
    }

    public State state;

    // Variables For Patrolling
    public GameObject[] waypoints;
    public int waypointIndex = 0;
    public float patrolSpeed = 0.5f;
    public Vector3 Destination;
    public float turnSpeed = 40f;

    //Variables for Chasing
    public float chaseSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "cop")
        {
            state = CRState.State.CHASE;
        }

        if (this.gameObject.tag == "robber")
        {
            state = CRState.State.RUNAWAY;
        }
    }

    IEnumerator FSM()
    {
        switch (state)
        {
            case State.RUNAWAY:
                Patrol();
                break;

            case State.CHASE:
                Chase();
                break;
        }

        yield return null;
    }

    void Patrol()
    {
        //Too far get closer
        if (Vector3.Distance(robbers.transform.position, waypoints[waypointIndex].transform.position) >= 2)
        {
            //This is where you are going
            Destination = waypoints[waypointIndex].transform.position;

            //Now move there
            float dist = patrolSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Destination, dist);

            var q = Quaternion.LookRotation(Destination - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);

            transform.LookAt(Destination);

            //Draw a ray cast to where you are going
            Vector3 distance = Destination - transform.position;
            Debug.DrawRay(transform.position, distance, Color.red);
        }
        else if (Vector3.Distance(robbers.transform.position, waypoints[waypointIndex].transform.position) <= 2)
        {
            waypointIndex += 1;
            if (waypointIndex >= 3)
            {
                waypointIndex = 0;
            }
        }
        else
        {
            transform.position = Vector3.zero;
        }

    }

    void Chase()
    {
        //If the player comes within reach of the enemy it will start to chase him
        Destination = cops.transform.position;

        //Set distance Now move towards it
        float dist = chaseSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Destination, dist);

        transform.LookAt(Destination);

        Vector3 distance = Destination - transform.position;
        Debug.DrawRay(transform.position, distance, Color.blue);

    }

    void Update()
    {
        // START FSM
        StartCoroutine("FSM");

        if (this.gameObject.tag == "cop")
        {
            state = CRState.State.CHASE;
        }

        if (this.gameObject.tag == "robber")
        {
            state = CRState.State.RUNAWAY;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        /*if(coll.tag == "Player")
        {
            state = EnemyState.State.CHASE;
        }*/

        if (coll.gameObject.tag == "cop")
        {
            Debug.Log("Caught the robber");
            this.gameObject.tag = "robber";
            coll.gameObject.tag = "cop";
        }

        if (coll.gameObject.tag == "robber")
        {
            Debug.Log("Got caught");
            this.gameObject.tag = "cop";
            coll.gameObject.tag = "robber";
        }
    }

}
