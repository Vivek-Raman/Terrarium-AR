using APIs.Data;
using APIs.Requests;
using APIs.Responses;
using Proyecto26;
using RSG;
using UnityEngine;

public static class APIController
{
    // private const string BASE_URL = "https://terrarium-ar.herokuapp.com";
    private const string BASE_URL = "http://192.168.0.193:6969";
    // private const string BASE_URL = "http://localhost:6969";

    public static class UserAPI
    {
        // calls /user/authenticate
        public static IPromise<UserAuthenticationResponse> Authenticate(string username, string password)
        {
            return RestClient.Post<UserAuthenticationResponse>(
                new RequestHelper
                {
                    Uri = BASE_URL + "/user/authenticate",
                    Method = "POST",
                    Body = new UserIdentifierRequest(username, password)
                });
        }

        // calls /user/register
        public static IPromise<UserRegistrationResponse> Register(string username, string password)
        {
            return RestClient.Post<UserRegistrationResponse>(
                new RequestHelper
                {
                    Uri = BASE_URL + "/user/register",
                    Method = "POST",
                    Body = new UserIdentifierRequest(username, password)
                });
        }
    }

    public static class RoomAPI
    {
        // calls /room/{userID}
        public static IPromise<RoomInfoResponse> GetRoomOfUser(string userID)
        {
            return RestClient.Get<RoomInfoResponse>(
                new RequestHelper
                {
                    Uri = BASE_URL + "/room/" + userID,
                    Method = "GET"
                });
        }

        public static IPromise<RoomInfoResponse> AddPlantToRoom(string userID, int speciesID, Transform transform)
        {
            return RestClient.Post<RoomInfoResponse>(
                new RequestHelper
                {
                    Uri = BASE_URL + "/room/add",
                    Method = "POST",
                    Body = new AddNewPlantToRoomRequest(userID, speciesID, transform)
                });
        }
    }
}