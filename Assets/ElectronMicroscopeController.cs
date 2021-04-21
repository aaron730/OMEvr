using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronMicroscopeController : MonoBehaviour
{
    public Sprite[] images;
    public Image imageComponent;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
