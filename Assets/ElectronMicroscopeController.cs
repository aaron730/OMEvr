using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronMicroscopeController : MonoBehaviour
{
    public BoxCollider microscopeCollider;
    public Sprite[] images;
    public Image imageComponent;
    public Text computerText;
    
    // Start is called before the first frame update
    void Start()
    {
        imageComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Ice"))
        {

            if (ObjectivesManager.Instance.CheckIfSpecificTaskIsComplete("GlacierSample"))
            {

                Debug.Log("entered");
                computerText.text = "Success";
                imageComponent.enabled = true;
                ObjectivesManager.Instance.CompleteTask("PlaceIceOnMicroscope", 1);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            
            if (ObjectivesManager.Instance.CheckIfSpecificTaskIsComplete("GlacierSample"))
            {

                Debug.Log("Exit");
                computerText.text = "";
                imageComponent.enabled = false;
                
            }
        }
    }

}
