using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydratorSnap : MonoBehaviour
{
    public Hydrator Hydrator;

    public void OnTriggerEnter(Collider other)
    {     
        FoodBag foodBag = other.GetComponent<FoodBag>();
        if (foodBag == null ||
            foodBag.AttatchedHydrator != null ||
            foodBag.IsHydrated ||
            Hydrator.AttatchedBag != null)
        {
            return;
        }

        foodBag.AttatchedHydrator = Hydrator;

        Debug.Log("Snapping bag to hydrator");

        Rigidbody otherRb = other.GetComponent<Rigidbody>();

        other.transform.parent = transform.parent;
        other.transform.localRotation = Quaternion.Euler(0, 180, 0);
        other.transform.localPosition = new Vector3(0.233f, 0, 0);
        otherRb.isKinematic = true;
        Hydrator.HydrateBag(other.gameObject);
    }
}
