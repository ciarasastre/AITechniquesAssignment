using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables For Patrolling
    public GameObject[] waypoints;
    public int waypointIndex = 0;
    public float CameraSpeed = 0.5f;
    public Vector3 Destination;
    public float turnSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Too far get closer
        if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) >= 4)
        {
            //This is where you are going
            Destination = waypoints[waypointIndex].transform.position;

            //Now move there
            float dist = CameraSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Destination, dist);

            var q = Quaternion.LookRotation(Destination - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, turnSpeed * Time.deltaTime);

            transform.LookAt(Destination);

            //Draw a ray cast to where you are going
            Vector3 distance = Destination - transform.position;
            Debug.DrawRay(transform.position, distance, Color.red);
        }
        else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) <= 4)
        {
            waypointIndex += 1;
            if (waypointIndex >= 5)
            {
                waypointIndex = 0;
            }
        }
        else
        {
            transform.position = Vector3.zero;
        }
    }
}
