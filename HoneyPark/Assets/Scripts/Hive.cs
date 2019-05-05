using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    int Pollen = 10;
    public GameObject Bee;
    public Vector3 spawnposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Pollen >= 5)
        {
            //Create a bee!
            Bee = new GameObject();
            SpawnArea();

            Pollen = Pollen - 5;
        }
    }

    void SpawnArea()
    {
        Instantiate(Bee, spawnposition, Quaternion.identity);
    }
}
