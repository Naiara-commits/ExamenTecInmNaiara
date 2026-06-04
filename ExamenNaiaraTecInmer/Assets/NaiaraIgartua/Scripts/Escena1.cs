using UnityEngine;
using Unity.XR.CoreUtils;

public class Escena1 : MonoBehaviour
{
    public int sceneIndex = 1;

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
