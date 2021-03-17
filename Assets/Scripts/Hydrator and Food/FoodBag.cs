using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBag : MonoBehaviour
{
    public Hydrator AttatchedHydrator;
    public bool IsHydrated;
    public Text NameText;
    public Text HydrationText;

    public void OnPickUp()
    {
        if (AttatchedHydrator != null && IsHydrated)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            AttatchedHydrator.DetatchBag();
            transform.parent = null;
            AttatchedHydrator = null;
        }
    }

    public void SetHydration(bool status)
    {
        if (status)
        {
            IsHydrated = true;
            HydrationText.text = "Hydrated";
        }
        else
        {
            IsHydrated = false;
            HydrationText.text = "Dehydrated";
        }
    }
}
