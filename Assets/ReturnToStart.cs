using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStart : MonoBehaviour
{
    Vector3 returnPoint;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        returnPoint = transform.position;
        time = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - time > 4)
        {
            transform.position = returnPoint;
            time = Time.realtimeSinceStartup;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
