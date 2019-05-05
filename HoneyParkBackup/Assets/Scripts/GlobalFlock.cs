using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject beePrefab;
    public static int hiveSize = 20;
    public static int numBees = 100;
    public static GameObject[] allBees = new GameObject[numBees];

    // This is if you want them to go to a specific location
    public GameObject goalPrefab;
    public GameObject hivePrefab;

    public static Vector3 goalPos = Vector3.zero; // Goal position

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBees; i++)
        {
            //Create bees and stick it in array around origin 
            /*Vector3 pos = new Vector3(Random.Range(1, hiveSize),
                                      Random.Range(1, hiveSize),
                                      Random.Range(1, hiveSize));*/

            Vector3 pos = new Vector3(Random.Range(15, 25),
                                  Random.Range(5, 16),
                                  Random.Range(1, hiveSize));

            //Vector3 pos = new Vector3(22,-1,11);
            allBees[i] = (GameObject)Instantiate(beePrefab, pos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Every couple of seconds the goal position is reset
        if(Random.Range (0,10000) < 50)
        {
            /*goalPos = new Vector3(Random.Range(1, hiveSize),
                                  Random.Range(1, hiveSize),
                                  Random.Range(1, hiveSize));*/

            goalPos = new Vector3(Random.Range(15, 25),
                                  Random.Range(5, 16),
                                  Random.Range(1, hiveSize));


            // New Goal Prefab code here:
            //Just add a sphere game object and your good to go!
            goalPrefab.transform.position = goalPos;
        }

        //goalPos = goalPrefab.transform.position;
    }
}
