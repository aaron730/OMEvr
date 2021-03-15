using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurfaceItems : MonoBehaviour
{
    // Start is called before the first frame update
    public string orbit, surface;
    static private SurfaceItems instance = null;
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (instance != null)
        {
            Debug.Log("destroy");
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        if (scene.name == "orbit")
        {
            this.gameObject.SetActive(false);
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(false);
            }
        }
        if (scene.name == "surface")
        {
            this.gameObject.SetActive(true);
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(true);
            }
        }
        instance = this;
    }

}

