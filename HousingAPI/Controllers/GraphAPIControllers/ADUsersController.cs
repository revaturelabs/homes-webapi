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
using HousingAPI.Models.ADModels;

namespace HousingAPI.Controllers.GraphAPIControllers
{

    public class ADUsersController : ApiController
    {
        // Get users in active directory
        [Authorize]
        [HttpGet]
        [ResponseType(typeof(ADUserJsonModel))]
        public IEnumerable<ADUserJsonModel> GetADUsers()
        {
            string responseString = "";
            string token = Request.Headers.Authorization.Parameter;

            HttpClient client = new HttpClient();
            
            Task.Run(async () =>
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/users");

                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", "Bearer " + token);

                HttpResponseMessage response = await client.SendAsync(message);
                responseString = await response.Content.ReadAsStringAsync();
            }).Wait();

            try
            {
                JToken parsed = JToken.Parse(responseString);

                //Parse response into appropiate model
                ADGetUsersJSONResponseModel aDUserList = new ADGetUsersJSONResponseModel()
                {
                    Context = parsed["@odata.context"].Value<string>(),
                    ADUserJsonModel = parsed["value"].Value<List<ADUserJsonModel>>()

                };

                return aDUserList.ADUserJsonModel;

            }
            catch
            {

                return null;

            }
        }

        //POST

        //PUT

        //DELETE
    }
}