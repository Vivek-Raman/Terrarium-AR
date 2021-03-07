using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;

    [SerializeField] private Button[] buttons = null;
    [SerializeField] private LoadingHandler spinner = null;

    public void UI_HandleRegister()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (!Validate(username, password))
        {
            return;
        }

        spinner.BeginLoading();
        SetButtonsActive(false);

        APIController.UserAPI.Register(username, password)
            .Then(response =>
            {
                spinner.CompleteLoading();
                SetButtonsActive(true);
                Debug.Log(response);
            })
            .Catch(e =>
            {
                spinner.CompleteLoading();
                SetButtonsActive(true);
                Debug.LogError(e.Message);
            });
    }

    public void UI_HandleLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (!Validate(username, password))
        {
            return;
        }

        spinner.BeginLoading();
        SetButtonsActive(false);

        APIController.UserAPI.Authenticate(username, password)
            .Then(response =>
            {
                if (response._status != "OK")
                {
                    // auth failed
                    spinner.CompleteLoading();
                    SetButtonsActive(true);
                    Debug.LogWarning(response._status);
                    return;
                }

                PrefsController.SaveUserSession(response);
                SceneManager.LoadSceneAsync("PortalDemo").completed += op =>
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("PortalDemo"));
                };

            })
            .Catch(e =>
            {
                spinner.CompleteLoading();
                SetButtonsActive(true);
                Debug.LogError(e.Message);
            });
    }

    private bool Validate(string username, string password)
    {
        return (username.Length > 0 && password.Length > 0);
    }

    private void SetButtonsActive(bool toSet)
    {
        for (int i = 0; i < buttons.Length; ++i)
        {
            buttons[i].interactable = toSet;
        }
    }
}