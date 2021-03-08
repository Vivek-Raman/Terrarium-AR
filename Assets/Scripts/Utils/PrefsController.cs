
using APIs.Responses;
using UnityEngine;

public static class PrefsController
{
    public static void SaveUserSession(UserAuthenticationResponse response)
    {
        PlayerPrefs.SetString("session_id", response.data.sessionID);
        PlayerPrefs.SetString("session_timestamp", response.data.lastLoginTimestamp);
        PlayerPrefs.SetString("user_id", response.data.user.userID);
        PlayerPrefs.SetString("user_name", response.data.user.userName);
        PlayerPrefs.SetInt("user_score", response.data.user.score);
    }

    public static string UserID => PlayerPrefs.GetString("user_id", null);
    public static string Username => PlayerPrefs.GetString("user_name", null);
    public static int    UserScore => PlayerPrefs.GetInt("user_score", -6969);
    public static string SessionID => PlayerPrefs.GetString("session_id", null);
    public static string SessionTimestamp => PlayerPrefs.GetString("session_timestamp", null);
}