using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrbitState : MonoBehaviour
{
    // Start is called before the first frame update
    public string orbit, surface;
    static private OrbitState instance = null;
    void Awake()
    {

        Scene scene = SceneManager.GetActiveScene();
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        if (scene.name == orbit)
        {
            this.gameObject.SetActive(false);
            Debug.Log(scene);
        }
        if (scene.name == surface)
        {
            this.gameObject.SetActive(true);
            Debug.Log(scene);
        }
        instance = this;
    }
}