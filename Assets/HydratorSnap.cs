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
        if (foodBag == null || foodBag.IsAttachedToHydrator)
        {
            return;
        }

        foodBag.IsAttachedToHydrator = true;

        Debug.Log("Snapping bag to hydrator");

        SnapPoint = OriginalSnapPoint.transform.position;
        Rigidbody otherRb = other.GetComponent<Rigidbody>();

        other.transform.parent = transform.parent;
        other.transform.localRotation = Quaternion.Euler(0, 180, 0);
        other.transform.localPosition = new Vector3(0.333f, 0, 0);
        otherRb.isKinematic = true;
        Hydrator.HydrateBag(other.gameObject);
    }
}
