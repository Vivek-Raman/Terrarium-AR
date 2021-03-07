using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Utilities : MonoBehaviour
{
    private bool debugPlaneState = false;

    public void UI_ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UI_ToggleDebugPlanes()
    {
        bool state = debugPlaneState.Toggle();
        foreach (ARPlane plane in FindObjectOfType<ARPlaneManager>().trackables)
        {
            plane.gameObject.SetActive(state);
        }
    }
}
