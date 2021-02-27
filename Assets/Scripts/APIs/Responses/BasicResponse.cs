using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public abstract class BasicResponse
    {
        public string _status;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}