using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using System.Net.Http.Headers;
using Microsoft;
using Microsoft.Graph;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Http.Description;

namespace HousingAPI.Controllers.GraphAPIControllers
{

    public class UserResponseModel
    {
        public string ObjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ADUsersController : ApiController
    {
        private static string audience = ConfigurationManager.AppSettings["ida:Audience"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientID"];

        // Get users in active directory
        //[Authorize]
        [HttpGet]
        [ResponseType(typeof(UserResponseModel))]
        public UserResponseModel GetADUsers()
        {
            string responseString = "";
            string token = Request.Headers.Authorization.Parameter;
            HttpClient client = new HttpClient();
            Task.Run(async () =>
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/users");

                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

                HttpResponseMessage response = await client.SendAsync(message);
                responseString = await response.Content.ReadAsStringAsync();
            }).Wait();

            try
            {
                UserResponseModel urm = new UserResponseModel();
                JToken parsed = JToken.Parse(responseString);
                urm.Email = parsed["value"][0]["userPrincipalName"].Value<string>();
                urm.FirstName = parsed["value"][0]["givenName"].Value<string>();
                urm.LastName = parsed["value"][0]["surname"].Value<string>();
                urm.ObjectId = parsed["value"][0]["id"].Value<string>();
                urm.PhoneNumber = parsed["value"][0]["mobilePhone"].Value<string>();

                return urm;

            }
            catch
            {

                return null;

            }
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");

            //message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

            //HttpResponseMessage response = await client.SendAsync(message);

            //string responseString = await response.Content.ReadAsStringAsync();

            //if (response.IsSuccessStatusCode)
            //{
            //    JObject user = JObject.Parse(responseString);
            //}
        }



    }
}