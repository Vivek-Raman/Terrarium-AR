using UnityEngine;

namespace APIs.Requests
{
    [System.Serializable]
    public class UserIdentifierRequest
    {
        public string userName;
        public string password;

        public UserIdentifierRequest(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}