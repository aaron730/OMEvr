using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Text CreditsText;
    public bool isScrolling = false;
    public void Start()
    {
        StartCredits();
    }
    public void StartCredits()
    {
        isScrolling = true;
    }

    public void FixedUpdate()
    {
        if (isScrolling)
        {
            CreditsText.transform.Translate(Vector3.up * .25f);
        }
    }
}
