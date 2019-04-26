using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGizmos : MonoBehaviour
{
    public int next = 0;
    public bool looped = true;

    public void OnDrawGizmos()
    {
        int count = looped ? (transform.childCount + 1) : transform.childCount;
        Gizmos.color = Color.blue;
        for (int i = 1; i < count; i++)
        {
            //Debug.Log("Works");
            Transform prev = transform.GetChild(i - 1);
            Transform next = transform.GetChild(i % transform.childCount);
            Gizmos.DrawLine(prev.transform.position, next.transform.position);
            Gizmos.DrawSphere(prev.position, 1);
            Gizmos.DrawSphere(next.position, 1);
        }
    }
}