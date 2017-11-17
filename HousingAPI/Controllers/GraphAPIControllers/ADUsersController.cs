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

namespace HousingAPI.Controllers.GraphAPIControllers
{

    public class ADUserModel
    {
        //[JsonProperty("Something")]
        //public int MyProperty { get; set; }

        //[JsonProperty("semthing2")]
        //public int Sem2 { get; set; }
    }

    public class ADUsersController : ApiController
    {
        private static string audience = ConfigurationManager.AppSettings["ida:Audience"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientID"];

        // Get users in active directory
        //[Authorize]
        //public string GetADUser()
        //{
        //    string responseString = "";
        //    HttpClient client = new HttpClient();
        //    Task.Run(async () =>
        //    {
        //        HttpResponseMessage response = await client.GetAsync("https://graph.microsoft.com/v1.0/me");
        //        responseString = await response.Content.ReadAsStringAsync();


        //        try
        //        {

        //            JToken parsed = JToken.Parse(responseString);
        //            string sub = parsed["sub"].Value<string>();
        //            return sub;

        //        }
        //        catch
        //        {

        //            return "Token Expired!";

        //        }
        //        //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");

        //        //message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

        //        //HttpResponseMessage response = await client.SendAsync(message);

        //        //string responseString = await response.Content.ReadAsStringAsync();

        //        //if (response.IsSuccessStatusCode)
        //        //{
        //        //    JObject user = JObject.Parse(responseString);
        //        //}
        //    }).Wait();
        //}



    }
}