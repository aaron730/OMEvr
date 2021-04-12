// Add this script to the GoalManager GameObject. It keeps track of all goals.
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{

    public Objectives objectives;

    

    public float TextMoveSpeed;

    
    public Text ChalkboardText;

    public AudioSource notificationSource;



    void Awake()
    {


        


        



        // StartCoroutine(MoveText());


    }

    private void FixedUpdate()
    {
        if(!objectives.CompletedSayHello())
        objectives.SayHello();

        if (!objectives.CompletedCollectRocks())
            objectives.CollectRocks();
        
    }



    // private IEnumerator MoveText()
    // {
    // yield return new WaitForSecondsRealtime(3);
    // VRTransform.position = new Vector3(0f, Mathf.Lerp(0f, VRDefault.y/* + (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
    // TwoDTransform.position = new Vector3(0f, Mathf.Lerp(0f, TwoDDefault.y /*+ (open ? openDistance : 0)*/, Time.deltaTime * TextMoveSpeed), 0f);
    //   }







}
// This is the abstract base class for all goals:
public abstract class ObjectiveList : MonoBehaviour
{
    public abstract bool CollectRocks();
    public abstract bool CompletedCollectRocks();
    public abstract bool SayHello();

    public abstract bool CompletedSayHello();



}