using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;

    public void UI_HandleRegister()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        APIController.UserAPI.Register(username, password)
            .Then(response =>
            {
                Debug.Log(response);
            })
            .Catch(e =>
            {
                Debug.LogError(e.Message);
            });
    }

    public void UI_HandleLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        APIController.UserAPI.Authenticate(username, password)
            .Then(response =>
            {
                Debug.Log(response);
            })
            .Catch(e =>
            {
                Debug.LogError(e.Message);
            });
    }
}