using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoManager : MonoBehaviour
{
    [Header("The 3 Actors")]
    [SerializeField] public GameObject man0;
    [SerializeField] public GameObject man1;
    [SerializeField] public GameObject man2;
    [SerializeField] public Transform teleportationAnchor;
    [SerializeField] public Transform actionCamAnchor;

    bool action = false;

    void Freeze(GameObject obj)
    {
        foreach (Rigidbody childBody in obj.transform.GetComponentsInChildren<Rigidbody>())
        {
            childBody.isKinematic = true;
            Collider coll = childBody.GetComponent<Collider>();
            if (coll != null) {
                childBody.GetComponent<Collider>().material.dynamicFriction = 0.1f;
                childBody.GetComponent<Collider>().material.staticFriction = 0.5f;
            }
            childBody.Sleep();
        }
    }

    void Drop(GameObject obj)
    {
        GameObject newObj = Instantiate(obj);
        obj = newObj.transform.Find("Sphere_Man/Group/Main/DeformationSystem/Root_M").gameObject;
            
        Freeze(obj);
        action = true;
        actionCamAnchor = obj.transform;
        obj.transform.position = teleportationAnchor.position;
        foreach (Rigidbody childBody in obj.transform.GetComponentsInChildren<Rigidbody>())
        {
            childBody.WakeUp();
            childBody.isKinematic = false;
        }
    }

    private void Awake()
    {
        Freeze(man0);
        Freeze(man1);
        Freeze(man2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (action)
        {
            Vector3 targetPos = actionCamAnchor.position +Vector3.forward * 10;
            Quaternion targetRot = Quaternion.EulerAngles(0,3.1415f,0);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos, 0.3f);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, targetRot, 0.3f);
            Camera.main.fieldOfView += (80 - Camera.main.fieldOfView) / 10f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Drop(man0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Drop(man1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Drop(man2);
    }
}
