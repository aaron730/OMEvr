using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text ButtonText;
    public GameObject SceneManager;

    private bool pushedOnce = false;
    public void OnPush()
    {
        if (!pushedOnce)
        {
            ButtonText.text = "You will leave Mars. Are you sure?";
            pushedOnce = true;
        }
        else
        {
            SceneManager.SetActive(true);
        }
    }
}
