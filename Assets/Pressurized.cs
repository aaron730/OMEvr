using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressurized : MonoBehaviour
{
    // Start is called before the first frame update


    public bool Pressureized;


    // Update is called once per frame

    public void ChangePressure()
    {
        Pressureized = !Pressureized;

    }
}
