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
    public class UIManager : MonoBehaviour
    {
        public ARPlaneManager planeManager;
        public Button exitButton;
        void ExitPressed()
        {
            SceneManager.LoadScene("MainMenu");
        }
        bool IsPointerOverUI()      //Función para detectar si estás sobre los botones
        {
            if (Pointer.current == null) return false;

            var screenPos = Pointer.current.position.ReadValue();

            var eventData = new PointerEventData(EventSystem.current)
            {
                position = screenPos
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            exitButton.onClick.AddListener(ExitPressed);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}


