namespace APIs.Data
{
    [System.Serializable]
    public class Session
    {
        public string sessionID;
        public string lastLoginTimestamp;
        public User user;
    }
}