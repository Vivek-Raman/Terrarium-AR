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
        public int growthState;


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
            this.growthState = 0;
        }
        
        public AddNewPlantToRoomRequest(string userID, int speciesID, Vector3 position, Vector3 rotation)
        {
            this.userID = userID;
            this.speciesID = speciesID;
            this.positionX = position.x;
            this.positionY = position.y;
            this.positionZ = position.z;
            this.rotationX = rotation.x;
            this.rotationY = rotation.y;
            this.rotationZ = rotation.z;
            this.growthState = 0;
        }
    }
}