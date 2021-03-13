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
        SceneManager.LoadScene("User Login");
    }
}
