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
        public PlaceOnPlane placeOnPlane;

        public TextMeshProUGUI planesCountText;
        public Button clearButton;
        public TMP_Dropdown prefabDropdown;
        public Button exitButton;

        public List<GameObject> prefabOptions = new List<GameObject>();
        

        void Start()
        {
            

            prefabDropdown.ClearOptions();
            var names = new List<string>();
            foreach (var prefab in prefabOptions)
                names.Add(prefab.name);
            prefabDropdown.AddOptions(names);

            //poner el primer prefab al iniciar 
            if (prefabOptions.Count > 0)
                placeOnPlane.placedPrefab = prefabOptions[0];
            prefabDropdown.onValueChanged.AddListener(OnDropdownChanged);
            clearButton.onClick.AddListener(OnClearPressed);
            exitButton.onClick.AddListener(ExitPressed);
        }
        void Update()
        {
            planesCountText.text = $"Planos: {planeManager.trackables.count}";      //Cuenta los planos
                // no puedes instanciar si hay boton donde apuntas
            placeOnPlane.inputBlocked = IsPointerOverUI();
        }
        void OnDropdownChanged(int index)
        {
            if (index >= 0 && index < prefabOptions.Count)
                placeOnPlane.placedPrefab = prefabOptions[index];
        }
        void OnClearPressed()
        {
            placeOnPlane.ClearAllObjects();
        }

        void ExitPressed()
        {
            SceneManager.LoadScene("EscenaInicial");
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

    }

}


