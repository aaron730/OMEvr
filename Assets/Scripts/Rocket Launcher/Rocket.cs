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

    public IEnumerator LaunchSequence()
    {
        IsLaunched = true;
        var timer = 3;

        while (timer > 0)
        {
            Debug.Log(timer);
            rb.AddForce(Vector3.up * 50000);
            timer--;
            yield return new WaitForSeconds(.5f);
        }

        //rb.isKinematic = true;
    }
}
