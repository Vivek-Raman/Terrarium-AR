using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public class BooleanResponse : BasicResponse
    {
        public bool data;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}