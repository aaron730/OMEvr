using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonExample : MonoBehaviour
    {
        public HoverButton hoverButton;

        public GameObject prefab;

        public GameObject SceneManager;

        public GameObject DontDestory;

        private void Start()
        {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
        }

        private void OnButtonDown(Hand hand)
        {
            DontDestory.SetActive(false);
            endScene();
        }

        private void endScene()
        {
            SceneManager.SetActive(true);
        }


    }
}