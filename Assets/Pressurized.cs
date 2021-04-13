using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressurized : MonoBehaviour
{

    public bool Pressureized;

    public void ChangePressure()
    {
        Pressureized = !Pressureized;
    }
}
