using HousingAPI.Models;
using HousingAPI.Models.ADModels;
//using System.Web.Mvc;
using Microsoft.Graph;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace HousingAPI.Controllers.GraphAPIControllers
{

    public class ADUsersController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        [NonAction]
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

                return parsed;

            }
            catch
            {
                return null;
            }
        }

        //POST
        [Authorize]
        [HttpPost]
        //[ResponseType(typeof(ADUserJsonModel))]
        public IHttpActionResult PostADUsers([FromBody] GUIReceivedUserJSONModel GUIReceivedUserJSONModel)
        {
            ADUserGraphTokenResponse aDUserGraphTokenResponse = GenerateAccessToken();

            ADUserJsonModel adUserJson = new ADUserJsonModel();

            HttpClient graphCRUDClient = new HttpClient();
            string responseString = "";

            Task.Run(async () =>
            {
                graphCRUDClient.BaseAddress = new Uri("https://graph.microsoft.com/v1.0/users");

                graphCRUDClient.DefaultRequestHeaders.Accept.Clear();

                graphCRUDClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + aDUserGraphTokenResponse.AccessToken);

                graphCRUDClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", aDUserGraphTokenResponse.AccessToken);

                Random rnd = new Random();
                int num1 = rnd.Next(0, 9);
                int num2 = rnd.Next(0, 9);
                int num3 = rnd.Next(0, 9);
                int num4 = rnd.Next(0, 9);

                Models.ADModels.PasswordProfile passwordProfile = new Models.ADModels.PasswordProfile()
                {
                    Password = "Jutu9475",
                    ForceChangePasswordNextSignIn = true
                };

                GraphAddUserJSONModel graphUser = new GraphAddUserJSONModel()
                {
                    AccountEnabled = true,
                    DisplayName = GUIReceivedUserJSONModel.FirstName + GUIReceivedUserJSONModel.LastName,
                    GivenName = GUIReceivedUserJSONModel.FirstName,
                    Surname = GUIReceivedUserJSONModel.LastName,
                    MobilePhone = GUIReceivedUserJSONModel.PhoneNumber,
                    MailNickname = GUIReceivedUserJSONModel.FirstName + GUIReceivedUserJSONModel.LastName.Substring(0, 1),
                    UserPrincipalName = GUIReceivedUserJSONModel.FirstName.ToLower() + "." + GUIReceivedUserJSONModel.LastName.ToLower() + Convert.ToString(num1) + Convert.ToString(num2) + Convert.ToString(num3) + Convert.ToString(num4) + "@andresgllive764.onmicrosoft.com",
                    PasswordPolicies = "DisablePasswordExpiration",
                    PasswordProfile = passwordProfile

                };

                string postBody = JsonConvert.SerializeObject(graphUser);

                var content = new StringContent(postBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await graphCRUDClient.PostAsync("", content);
                responseString = await response.Content.ReadAsStringAsync();
            }).Wait();

            try
            {
                JToken parsed = JToken.Parse(responseString);



                adUserJson.Id = parsed["id"].Value<string>();
                adUserJson.DisplayName = parsed["displayName"].Value<string>();
                adUserJson.GivenName = parsed["givenName"].Value<string>();
                adUserJson.JobTitle = parsed["jobTitle"].Value<string>();
                adUserJson.Mail = parsed["mail"].Value<string>();
                adUserJson.MobilePhone = parsed["mobilePhone"].Value<string>();
                adUserJson.OfficeLocation = parsed["officeLocation"].Value<string>();
                adUserJson.PreferredLanguage = parsed["preferredLanguage"].Value<string>();
                adUserJson.surname = parsed["surname"].Value<string>();
                adUserJson.UserPrincipalName = parsed["userPrincipalName"].Value<string>();


                Models.Contact contact = new Models.Contact()
                {
                    email = adUserJson.UserPrincipalName,
                    objectId = adUserJson.Id,
                    firstName = adUserJson.GivenName,
                    lastName = adUserJson.surname,
                    phoneNumber = adUserJson.MobilePhone

                };

                db.Contacts.Add(contact);
                db.SaveChanges();

                return Ok();

            }
            catch
            {

                return InternalServerError();

            }

        }

        //PUT

        //DELETE

        //Dispose database
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}


