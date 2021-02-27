using APIs.Requests;
using APIs.Responses;
using Proyecto26;
using RSG;
using UnityEngine;

public static class APIController
{
    // private const string BASE_URL = "https://terrarium-ar.herokuapp.com";
    private const string BASE_URL = "http://192.168.1.11:6969";

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


}