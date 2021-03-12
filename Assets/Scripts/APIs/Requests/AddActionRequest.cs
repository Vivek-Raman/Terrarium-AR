using APIs.Data;
using APIs.Data.Enum;

namespace APIs.Requests
{
    [System.Serializable]
    public class AddActionRequest
    {
        public Plant plant;
        public ActionType actionType;

        public AddActionRequest(Plant plant, ActionType actionType)
        {
            this.plant = plant;
            this.actionType = actionType;
        }
    }
}