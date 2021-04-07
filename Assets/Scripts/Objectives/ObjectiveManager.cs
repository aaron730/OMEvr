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
    public Text ChalkboardText;

    public AudioSource notificationSource;

    void Awake()
    {


        VRText = VRCanvas.GetComponentInChildren<Text>();
        TwoDText = TwoDCanvas.GetComponentInChildren<Text>();



        TwoDText.horizontalOverflow = HorizontalWrapMode.Overflow;
        VRText.horizontalOverflow = HorizontalWrapMode.Overflow;
        TwoDText.color = new Color(255, 255, 255);
        objectives = GetComponents<Objective>();
        StartCoroutine(DelayUpdate());

        // StartCoroutine(MoveText());


    }

    private IEnumerator DelayUpdate()
    {
        foreach (var objective in objectives)
        {
            for (int i = 1; i <= 4; i++)
            {
                TwoDText.text = objective.DrawHUD(i);
                VRText.text = objective.DrawHUD(i);
                Debug.Log(objective.GetComponentInChildren<Welcome>());
                if (i == 3 && !objective.GetComponentInChildren<Welcome>().IsAchieved())
                {

                    notificationSource.Play();
                }




                yield return new WaitForSecondsRealtime(3);



            }




        }

        yield return null;
    }

    // private IEnumerator MoveText()
    // {
    // yield return new WaitForSecondsRealtime(3);
    // VRTransform.position = new Vector3(0f, Mathf.Lerp(0f, VRDefault.y/* + (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
    // TwoDTransform.position = new Vector3(0f, Mathf.Lerp(0f, TwoDDefault.y /*+ (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
    //   }

    private IEnumerator DontOverload()
    {
        int i = 0;
        while (i != objectives.Length)
        {
            ChalkboardText.text = objectives[i].DrawChalkboard();
            Debug.Log(objectives[i].DrawChalkboard());
            if (objectives[i].IsAchieved())
            {
               
                Debug.Log("hit");
                objectives[i].Complete();
                Destroy(objectives[i]);
                i++;
            }
            
            
                

            yield return new WaitForSecondsRealtime(1);

        }
        yield return null;
    }




    void LateUpdate()
    {

        StartCoroutine(DontOverload());
        ChalkboardText.text = null ;
    }

}

    // This is the abstract base class for all goals:
    public abstract class Objective : MonoBehaviour
    {
        public abstract bool IsAchieved();
        public abstract void Complete();
        public abstract string DrawHUD(int callNumber);

        public abstract string DrawChalkboard();


    }
