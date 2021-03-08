using APIs.Data;
using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public class RoomInfoResponse : BasicResponse
    {
        public Plant[] plants;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}