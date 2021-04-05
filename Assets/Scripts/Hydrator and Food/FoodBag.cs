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

    public GameObject FoodToSpawn;

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

    public void OpenBag()
    {
        if (!IsHydrated)
        {
            return;
        }
        GameObject go = Instantiate(FoodToSpawn);
        go.transform.position = transform.position;
        Destroy(transform.gameObject);
        Debug.Log("Opening bag!");
    }
}
