using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public class UserRegistrationResponse : BasicResponse
    {
        public bool data;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}