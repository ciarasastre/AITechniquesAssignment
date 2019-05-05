using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public float speed = 0.001f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading; // Where they are going / heading towards
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;

    bool turning = false; // makes them stay within boundries

    // Start is called before the first frame update
    void Start()
    {
        //Makes the flock move differently EG some move faster than others
        speed = Random.Range(0.5f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Testing distance of bees pos and hives center
        if(Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.hiveSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        //Turn around and go back
        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Rules get called at certain times
            if (Random.Range(0, 5) < 1)
            {
                ApplyRules();
            }
        }
        //Makes the bees go forward
        transform.Translate(0,0,Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        //Find out all the bees
        GameObject[] gos; //gos = gameobjects
        gos = GlobalFlock.allBees;

        //Then calculate center of a group and avoidance
        Vector3 vcentre = Vector3.zero; // Center of group
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;

        // Calculate group size
        foreach(GameObject go in gos) //For each of the gameobjects
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);

                //Get group size if your close to us your part of our group
                if(dist <= neighbourDistance)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    //If we get too close we need to avoid each other
                    if(dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>(); //Grab flock script from neighbours
                    gSpeed = gSpeed + anotherFlock.speed; // Getting speed to get total speed
                }

            }
        }

        //If we are in a group
        if(groupSize > 0)
        {
            //Calc average center and speed of group
            vcentre = vcentre / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            //Get direction
            Vector3 direction = (vcentre + vavoid) - transform.position;

            if(direction != Vector3.zero)
            {
                //Change direction means change of rotation
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                        Quaternion.LookRotation(direction),
                                                        rotationSpeed * Time.deltaTime);
            }
        }

    }
}
