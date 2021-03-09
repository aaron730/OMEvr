using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydratorSnap : MonoBehaviour
{
    public Transform OriginalSnapPoint;
    public Hydrator Hydrator;
    private Vector3 SnapPoint;
    public void Start()
    {
        SnapPoint = OriginalSnapPoint.transform.position;
    }
    public void OnTriggerEnter(Collider other)
    {     
        FoodBag foodBag = other.GetComponent<FoodBag>();
        if (foodBag.IsAttachedToHydrator)
        {
            return;
        }

        foodBag.IsAttachedToHydrator = true;

        Debug.Log("Snapping bag to hydrator");

        SnapPoint = OriginalSnapPoint.transform.position;
        Rigidbody otherRb = other.GetComponent<Rigidbody>();

        /*
        // Gets half the width of bag's box collider and adds it to snap point
        BoxCollider otherCollider = other.GetComponent<BoxCollider>();
        SnapPoint = SnapPoint + new Vector3(otherCollider.size.x / 2, 0, 0);
        */

        other.transform.rotation = OriginalSnapPoint.rotation;
        Debug.Log(SnapPoint + "  " +foodBag.SnapPoint.TransformPoint(foodBag.SnapPoint.position));
        SnapPoint = SnapPoint + new Vector3(0, foodBag.SnapPoint.position.y, 0);
        other.transform.position = SnapPoint;
        otherRb.isKinematic = true;
        Hydrator.HydrateBag(other.gameObject);
    }
}
