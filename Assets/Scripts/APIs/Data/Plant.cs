using System;

namespace APIs.Data
{
    [Serializable]
    public class Plant
    {
        public string plantID;
        public int speciesID;
        public User user;
        public string dateOfPlanting;
        public int positionX;
        public int positionY;
        public int positionZ;
        public int rotationX;
        public int rotationY;
        public int rotationZ;
        public int unwateredDayCount;
        public int growthState;
    }
}