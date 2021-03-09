using UnityEngine;

namespace APIs.Responses
{
    [System.Serializable]
    public class AddNewPlantToRoomRequest
    {
        public string userID;
        public int speciesID;
        public float positionX;
        public float positionY;
        public float positionZ;
        public float rotationX;
        public float rotationY;
        public float rotationZ;

        public AddNewPlantToRoomRequest(string userID, int speciesID, Transform transform)
        {
            this.userID = userID;
            this.speciesID = speciesID;
            this.positionX = transform.position.x;
            this.positionY = transform.position.y;
            this.positionZ = transform.position.z;
            this.rotationX = transform.rotation.eulerAngles.x;
            this.rotationY = transform.rotation.eulerAngles.y;
            this.rotationZ = transform.rotation.eulerAngles.z;
        }
    }
}