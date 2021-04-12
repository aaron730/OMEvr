using UnityEngine;
using Valve.VR.InteractionSystem;

public class introButton : MonoBehaviour
{
    // Sliding door
    public enum OpenDirection { x, y, z }
    public OpenDirection direction = OpenDirection.y;
    public float openDistance = 3f; //How far should door slide (change direction by entering either a positive or a negative value)
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster
    public Transform doorBody; //Door body Transform
    private bool doorOpen = false;
    public DayCycleController cycleController;
    public AudioSource DoorOpen;
    public float timeToClose = 3f;

    bool open = false;

    Vector3 defaultDoorPosition;

    void Start()
    {
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
        }
    }

    // Main function
    void FixedUpdate()
    {
        if (!doorBody)
            return;


        if (direction == OpenDirection.x)
        {
            doorBody.localPosition = new Vector3(Mathf.Lerp(doorBody.localPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.y, doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {

            doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);

        }
        else if (direction == OpenDirection.z)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        }

    }



    // Activate the Main function when Player enter the trigger ar





    // Deactivate the Main function when Player exit the trigger area
    /*void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open = false;
        }
    }

    */
    public void OnPress(Hand hand)
    {
    
            if (doorOpen == false)
            {
                Debug.Log("open1");
                open = true;
                if (openDistance <= doorBody.position.y - .1)
                {
                    doorOpen = true;

                    Invoke("Close", timeToClose);
                DoorOpen.Play();
                }
            }
        //else
        //{
        //    Debug.Log("open2");
        //    open = false;
        //    doorOpen = false;


        //}



    }

    public void Close()
    {
        open = false;
        doorOpen = false;

    }


    public void PlantPress(Hand hand)
    {
        cycleController.orbitSpeed = 1;
    }



}