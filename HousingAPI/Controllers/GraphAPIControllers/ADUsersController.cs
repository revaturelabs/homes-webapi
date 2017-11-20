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
        public ADUserGraphTokenResponse GenerateAccessToken()
        {
            ADUserGraphTokenResponse aDUserGraphTokenResponse = new ADUserGraphTokenResponse();

            HttpClient tokenClient = new HttpClient();

            Task.Run(async () =>
            {
                tokenClient.BaseAddress = new Uri("https://login.microsoftonline.com/" + ConfigurationManager.AppSettings["ida:Tenant"] + "/oauth2/v2.0/token");
                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("tenant", ConfigurationManager.AppSettings["ida:Tenant"]),
                new KeyValuePair<string, string>("client_id", ConfigurationManager.AppSettings["ida:Audience2"]),
                new KeyValuePair<string, string>("scope", "https://graph.microsoft.com/.default"),
                new KeyValuePair<string, string>("client_secret", ConfigurationManager.AppSettings["ida:Secret2"]),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });
                var result = await tokenClient.PostAsync("", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                JToken parsedResult = JToken.Parse(resultContent);

                aDUserGraphTokenResponse.AccessToken = parsedResult["access_token"].Value<string>();
                aDUserGraphTokenResponse.ExpiresIn = parsedResult["expires_in"].Value<string>();
                aDUserGraphTokenResponse.TokenType = parsedResult["token_type"].Value<string>();

            }).Wait();

            return aDUserGraphTokenResponse;
        }

        // Get users in active directory
        [Authorize]
        [HttpGet]
        [ResponseType(typeof(ADUserJsonModel))]
        public JToken GetADUsers()
        {
            ADUserGraphTokenResponse aDUserGraphTokenResponse = GenerateAccessToken();

            HttpClient graphCRUDClient = new HttpClient();
            string responseString = "";

            Task.Run(async () =>
            {
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/users");

                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", aDUserGraphTokenResponse.AccessToken);

                HttpResponseMessage response = await graphCRUDClient.SendAsync(message);
                responseString = await response.Content.ReadAsStringAsync();
            }).Wait();

            try
            {
                JToken parsed = JToken.Parse(responseString);

                ////Parse response into appropiate model
                //ADGetUsersJSONResponseModel aDUserList = new ADGetUsersJSONResponseModel()
                //{
                //    Context = parsed["@odata.context"].Value<string>(),
                //    //ADUserJsonModel = parsed["value"].Value<List<ADUserJsonModel>>()

                //};

                //foreach (var item in parsed["value"].Value<List<ADUserJsonModel>>())
                //{
                //    aDUserList.ADUserJsonModel.Add(item);
                //}

                //return aDUserList.ADUserJsonModel;
                return parsed;

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