using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    // Start is called before the first frame update

    public Pressurized pressurized;

    public Material red;

    public Material green;
    // Update is called once per frame
    void Update()
    {
        if (pressurized.Pressureized == true)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = green;

        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material = red;
        }
    }
}
