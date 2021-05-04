using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject Rover;

    // Update is called once per frame
    void Update()
    {
        if (((player.transform.position - this.transform.position).sqrMagnitude < 3 * 5) ||( (Rover.transform.position - this.transform.position).sqrMagnitude < 3 * 5))
        {
           this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;

        }
    }

} 
