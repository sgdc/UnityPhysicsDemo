using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RopeRender : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    LineRenderer renderer;


    // Update is called once per frame
    void Update()
    {
        renderer.SetPositions(new Vector3[] { transform.position, target.position });
    }
}
