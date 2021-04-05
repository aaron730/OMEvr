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
        IsLaunched = true;
        StartCoroutine(LaunchSequence());
    }

    public IEnumerator LaunchSequence()
    {
        var timer = 10;

        while (timer > 0)
        {
            Debug.Log(timer);
            rb.AddForce(Vector3.up * 100000);
            timer--;
            yield return new WaitForSeconds(1);
        }
    }
}
