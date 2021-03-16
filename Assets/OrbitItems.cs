using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbitItems : MonoBehaviour
{
    // Start is called before the first frame update
    public string orbit, surface;
    static private OrbitItems instance = null;
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
            this.gameObject.SetActive(true);
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(true);
            }
        }
        if (scene.name == "surface")
        {
            this.gameObject.SetActive(false);
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                child.gameObject.SetActive(false);
            }
        }

        instance = this;
    }
}
