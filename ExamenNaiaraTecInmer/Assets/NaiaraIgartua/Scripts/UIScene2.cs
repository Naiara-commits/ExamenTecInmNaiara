using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation.Samples;
using UnityEngine.SceneManagement;
namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class UIScene2 : MonoBehaviour
    {
        [SerializeField] public Button exitButton;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            exitButton.onClick.AddListener(ExitPressed);
        }
        void ExitPressed()
        {
            SceneManager.LoadScene("EscenaInicial");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }


}


