using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTrigger : MonoBehaviour
{
    public Scanner ParentScanner;
    public List<Collider> colliders = new List<Collider>();
    public GameObject ScannerBar;

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
                CancelScan();
                return;
            }
            StartCoroutine(Scan(other.gameObject));
            ParentScanner.Scanning();
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
                CancelScan();
                ParentScanner.RemoveRock();
            }
        }
    }

    private void CancelScan()
    {
        StopAllCoroutines();
        ScannerBar.GetComponent<MeshRenderer>().enabled = false;
    }

    private IEnumerator Scan(GameObject rock)
    {
        ScannerBar.GetComponent<MeshRenderer>().enabled = true;
        Vector3 starterPos = new Vector3(-0.0412f, -0.37118f, -0.28807f);
        Vector3 endPos = new Vector3(-0.0412f, -0.37118f, .309f);
        ScannerBar.transform.localPosition = starterPos;

        float currentZ = starterPos.z;
        while (currentZ <= endPos.z)
        {
            currentZ += .01f;
            ScannerBar.transform.localPosition = new Vector3(-0.0412f, -0.37118f, currentZ);
            yield return new WaitForSeconds(.01f);
        }

        while (currentZ >= starterPos.z)
        {
            currentZ -= .01f;
            ScannerBar.transform.localPosition = new Vector3(-0.0412f, -0.37118f, currentZ);
            yield return new WaitForSeconds(.01f);
        }
        ScannerBar.GetComponent<MeshRenderer>().enabled = false;
        ParentScanner.ScanRock(rock);
    }
}
