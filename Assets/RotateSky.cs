using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public GameObject Station;
    public List<GameObject> InitalForceObjects = new List<GameObject>();

    public void Start()
    {
        //Debug.Log(InitalForceObjects.Count);
        Physics.gravity = Vector3.zero;
        ApplyForces();
    }
    public void ApplyForces()
    {
        foreach(GameObject x in InitalForceObjects)
        {
            x.GetComponent<Rigidbody>().AddForce(new Vector3(3, 1, 1));
        }
    }
    public void Update()
    {
        Station.transform.Rotate(Vector3.right * Time.deltaTime);
    }
}
