// Add this script to the GoalManager GameObject. It keeps track of all goals.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{

    public Objective[] objectives;
    
    public Canvas VRCanvas;
    public Canvas TwoDCanvas;
    public float TextMoveSpeed;

    private Text VRText;
    private Text TwoDText;
    private Transform VRTransform;
    private Transform TwoDTransform;
    private Vector3 VRPosition;
    private Vector3 TwoDPosition;
    private Vector3 VRDefault;
    private Vector3 TwoDDefault;

    public AudioSource notificationSource;

    void Awake()
    {
        
        
        VRText = VRCanvas.GetComponentInChildren<Text>();
        TwoDText = TwoDCanvas.GetComponentInChildren<Text>();
        VRTransform = VRText.transform;
        TwoDTransform = TwoDTransform.transform;
        TwoDDefault = TwoDTransform.localPosition;
        VRDefault = VRTransform.localPosition;
        

        TwoDText.horizontalOverflow = HorizontalWrapMode.Overflow;
        VRText.horizontalOverflow = HorizontalWrapMode.Overflow;
        TwoDText.color = new Color(255, 255, 255);
        objectives = GetComponents<Objective>();
        StartCoroutine(DelayUpdate());
        StartCoroutine(MoveText());


    }

    private IEnumerator DelayUpdate()
    {
        foreach (var objective in objectives)
        {
            for (int i = 1; i <= 3; i++)
            {
                TwoDText.text = objective.DrawHUD(i);
                VRText.text = objective.DrawHUD(i);
                if(i == 3)
                {
                    notificationSource.Play();
                }
                yield return new WaitForSecondsRealtime(3);
                
            }

            


            
        }
        
        yield return null;
    }

    private IEnumerator MoveText()
    {
        yield return new WaitForSecondsRealtime(3);
        VRTransform.position = new Vector3(0f, Mathf.Lerp(0f, VRDefault.y/* + (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
        TwoDTransform.position = new Vector3(0f, Mathf.Lerp(0f, TwoDDefault.y /*+ (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
    }

        private void FixedUpdate()
    {
       
        
    }

    void Update()
    {


        foreach (var objective in objectives)
        {
            if (objective.IsAchieved())
            {
                objective.Complete();
                Destroy(objective);
                
            }
            
        }
    }
}

 
 
// This is the abstract base class for all goals:
public abstract class Objective : MonoBehaviour
{
    public abstract bool IsAchieved();
    public abstract void Complete();
    public abstract string DrawHUD(int callNumber);


}
