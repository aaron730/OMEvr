using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTrigger : MonoBehaviour
{
    public Scanner ParentScanner;
    public List<Collider> colliders = new List<Collider>();

    public void Start()
    {
        ParentScanner = GetComponentInParent<Scanner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if(other.tag == "IntroObject")
        {
            if (!colliders.Contains(other)) { colliders.Add(other); }
            if(colliders.Count > 1)
            {
                ParentScanner.TooManyRocks();
                return;
            }
            ParentScanner.ScanRock(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        if (other.tag == "MarsRock")
        {
            colliders.Remove(other);
            if (colliders.Count == 0)
            {
                ParentScanner.RemoveRock();
            }
        }
    }
}
