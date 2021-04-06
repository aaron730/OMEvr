using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rb;
    public bool IsLaunched;

    public void Start()
    {
        IsLaunched = false;
        rb = GetComponent<Rigidbody>();
    }
    public void Launch()
    {
        StartCoroutine(LaunchSequence());
    }

    public void Return()
    {
        EnableRocket();
    }

    public void DisableRocket()
    {
        rb.isKinematic = true;
        MeshRenderer[] list = GetComponentsInChildren<MeshRenderer>();
        foreach( MeshRenderer x in list)
        {
            x.enabled = false;
        }
        
    }

    public void EnableRocket()
    {
        rb.isKinematic = false;
        MeshRenderer[] list = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer x in list)
        {
            x.enabled = true;
        }
    }

    public IEnumerator LaunchSequence()
    {
        IsLaunched = true;
        var timer = 3;

        while (timer > 0)
        {
            Debug.Log(timer);
            rb.AddForce(Vector3.up * 80000);
            timer--;
            yield return new WaitForSeconds(.5f);
        }
        yield return new WaitForSeconds(10);
        DisableRocket();
    }
}
