using UnityEngine;

namespace APIs.Data
{
    [System.Serializable]
    public class Plant
    {
        public string plantID;
        public int speciesID;
        public User user;
        public string dateOfPlanting;
        public float positionX;
        public float positionY;
        public float positionZ;
        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public int unwateredDayCount;
        public int growthState;

        public int GrowthState => Mathf.Clamp(growthState, 0, 8);

        public Plant(string plantID, int speciesID, User user, string dateOfPlanting, float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, int unwateredDayCount, int growthState)
        {
            this.plantID = plantID;
            this.speciesID = speciesID;
            this.user = user;
            this.dateOfPlanting = dateOfPlanting;
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.rotationX = rotationX;
            this.rotationY = rotationY;
            this.rotationZ = rotationZ;
            this.unwateredDayCount = unwateredDayCount;
            this.growthState = growthState;
        }
    }
}