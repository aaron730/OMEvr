using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public AudioSource FoodNoise;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Head")
        {
            Debug.Log("Eat");
            FoodNoise.Play();
            GetComponentInParent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 3);
        }
    }
}
