using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{

    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position += moveSpeed * (transform.up*Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal"));
        }

        if(Input.GetMouseButton(1))
        transform.Rotate(Vector3.up, 10*Input.GetAxisRaw("Mouse X"));
    }
}
