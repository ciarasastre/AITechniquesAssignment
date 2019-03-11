using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persue : SteeringBehaviour
{
    public Boid target;

    Vector3 targetPos;

    //This section draws gizmos so you can see target and distance from gameobject
    public void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, targetPos);
        }
    }

    public override Vector3 Calculate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        float time = dist / boid.maxSpeed;

        targetPos = target.transform.position + (target.velocity * time);

        return boid.SeekForce(targetPos);
    }
}
