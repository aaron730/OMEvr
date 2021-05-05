using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    public GameObject Station;

    public void Start()
    {
        Physics.gravity = Vector3.zero;
    }
    public void Update()
    {
        Station.transform.Rotate(Vector3.right * Time.deltaTime);
    }
}
