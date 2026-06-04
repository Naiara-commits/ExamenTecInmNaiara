using UnityEngine;
using Unity.XR.CoreUtils;

public class Escena1 : MonoBehaviour
{
    public int sceneIndex = 1;
    public GameObject cubo1Prefab;
    public GameObject cubo2Prefab;
    void Start()
    {
        Instantiate(cubo1Prefab, new Vector3(0.86f, 2.5f, 0.39f), Quaternion.identity);
        Instantiate(cubo2Prefab, new Vector3(0.93f, 2.5f, -1.1f), Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        XROrigin xrOrigin = other.GetComponentInParent<XROrigin>();
        if (xrOrigin == null) return;
     
        SceneSelector.Instance.ShowUI(sceneIndex);  
    }

    private void OnTriggerExit(Collider other)
    {
        XROrigin xrOrigin = other.GetComponentInParent<XROrigin>();
        if (xrOrigin == null) return;

        SceneSelector.Instance.HideUI();
    }
  
}
