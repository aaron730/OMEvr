using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        Launch();
    }
    public void Launch()
    {
        StartCoroutine(LaunchSequence());
    }

    public IEnumerator LaunchSequence()
    {
        var timer = 10;
        yield return new WaitForSeconds(5);
        while (timer > 0)
        {
            Debug.Log(timer);
            rb.AddForce(Vector3.up * 100000);
            timer--;
            yield return new WaitForSeconds(1);
        }
    }
}
