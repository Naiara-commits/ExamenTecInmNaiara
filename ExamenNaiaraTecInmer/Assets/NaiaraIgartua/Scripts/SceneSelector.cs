using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSelector : MonoBehaviour
{
    public static SceneSelector Instance;
    [SerializeField] public GameObject ui;
    [SerializeField] public TMP_Text pregunta;
    [SerializeField] Button escena;

    private int _pendingScene = -1;

    private void Awake()
    {
        Instance = this;
        ui.SetActive(false);     
    }

    public void ShowUI(int sceneIndex)
    {
        _pendingScene = sceneIndex;
        pregunta.text = $"¿Ir a la Escena {sceneIndex}?";
        ui.SetActive(true);
    }

    public void HideUI()
    {
        _pendingScene = -1;
        ui.SetActive(false);
    }
    public void OnConfirm()
    {
        if (_pendingScene >= 0)
            SceneManager.LoadScene(_pendingScene);
    }
    
}
