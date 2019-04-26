using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsAndRobbers : SteeringBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boid target;

    Vector3 targetPos;
    public Path path;

    Vector3 nextWaypoint;

    //This section draws gizmos so you can see target and distance from gameobject
    public void OnDrawGizmos()
    {
        //This shows the distance from waypoint to waypoint
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, nextWaypoint);
        }

        //This shows the distance of cop to robber
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetPos);
        }
    }

    public override Vector3 Calculate()
    {
        //Persuing robber if he is the cop
        if (this.gameObject.tag == "cop")
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            float time = dist / boid.maxSpeed;

            targetPos = target.transform.position + (target.velocity * time);

            return boid.SeekForce(targetPos);
        }
        else
        {
            //If he is a robber he needs to run
            nextWaypoint = path.NextWaypoint();
            if (Vector3.Distance(transform.position, nextWaypoint) < 3)
            {
                path.AdvanceToNext();
            }

            if (!path.looped && path.IsLast())
            {
                return boid.ArriveForce(nextWaypoint, 20);
            }
            else
            {
                return boid.SeekForce(nextWaypoint);
            }
        }

    }

    //If they touch change states
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "robber")
        {
            Debug.Log("Caught the robber");
            this.gameObject.tag = "robber";
            col.gameObject.tag = "cop";
        }

        if (col.gameObject.tag == "cop")
        {
            Debug.Log("Got caught");
            this.gameObject.tag = "cop";
            col.gameObject.tag = "robber";
        }

    }
}
