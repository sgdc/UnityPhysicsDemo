using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public float catchingDistance = 3f;
    bool isDragging = false;
    GameObject draggingObject;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isDragging)
            {
                draggingObject = GetObjectFromMouseRaycast();
                if (draggingObject)
                {
                    isDragging = true;
                }
            }
            else if (draggingObject != null)
            {
                draggingObject.GetComponent<Rigidbody>().AddForce(CalculateMouse3DVector());
            }
        }
        else
        {
            if (draggingObject != null)
            {
            }
            isDragging = false;
        }
    }

    Vector3 dragAnchor;
    Vector3 draganchor3d;

    private GameObject GetObjectFromMouseRaycast()
    {
        GameObject gmObj = null;
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>() &&
                Vector3.Distance(hitInfo.collider.gameObject.transform.position,
                transform.position) <= catchingDistance)
            {
                gmObj = hitInfo.collider.gameObject;

                dragAnchor = Input.mousePosition;
                draganchor3d = gmObj.transform.position;
            }
        }
        return gmObj;
    }
    private Vector3 CalculateMouse3DVector()
    {
        Vector3 v3 = Input.mousePosition - dragAnchor;
        v3 = Quaternion.LookRotation(draganchor3d - transform.position) * v3;
        v3 *= 1f;
        return v3;
    }
}
