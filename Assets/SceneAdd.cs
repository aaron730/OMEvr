using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneAdd : MonoBehaviour
{

    public GameObject player;
    // Update is called once per frame
   public void loadOrbit()
    {
        SceneManager.LoadScene("Loading Test", LoadSceneMode.Additive);
        player.transform.position = new Vector3(0, -25, 0);
    }

    public void loadSurface()
    {
        player.transform.position = new Vector3(0, 0, 0);

    }
}
