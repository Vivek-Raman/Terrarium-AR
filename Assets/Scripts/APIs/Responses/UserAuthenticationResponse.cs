using APIs.Data;
using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public class UserAuthenticationResponse : BasicResponse
    {
        public Session data;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}