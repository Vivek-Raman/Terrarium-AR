using APIs.Data;
using APIs.Data.Enum;

namespace APIs.Requests
{
    [System.Serializable]
    public class AddActionRequest
    {
        public string plantID;
        public ActionType actionType;

        public AddActionRequest(string plantID, ActionType actionType)
        {
            this.plantID = plantID;
            this.actionType = actionType;
        }
    }
}