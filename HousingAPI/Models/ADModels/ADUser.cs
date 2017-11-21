using Newtonsoft.Json;
using System.Collections.Generic;

namespace HousingAPI.Models.ADModels
{
    public class ADUserGraphTokenResponse
    {
        //[JsonProperty("token_type")]
        public string TokenType { get; set; }

        ////[JsonProperty("scope")]
        //public string Scope { get; set; }

        //[JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        ////[JsonProperty("ext_expires_in")]
        //public string ExtExpiresIn { get; set; }

        //[JsonProperty("access_token")]
        public string AccessToken { get; set; }

        ////[JsonProperty("refresh_token")]
        //public string RefreshToken { get; set; }
    }
    public class ADUserResponseModel
    {
        public string ObjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ADGetUsersJSONResponseModel
    {
        [JsonProperty("@odata.context")]
        public string Context { get; set; }

        [JsonProperty("value")]
        public List<ADUserJsonModel> ADUserJsonModel { get; set; }
    }

    public class ADUserJsonModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("businessPhones")]
        public List<string> BusinessPhones { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("officeLocation")]
        public string OfficeLocation { get; set; }

        [JsonProperty("preferredLanguage")]
        public string PreferredLanguage { get; set; }

        [JsonProperty("surname")]
        public string surname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }
    }

    public class PasswordProfile
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("forceChangePasswordNextSignIn")]
        public bool ForceChangePasswordNextSignIn { get; set; }
    }

    public class GraphAddUserJSONModel
    {
        [JsonProperty("accountEnabled")]
        public bool AccountEnabled { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("mailNickname")]
        public string MailNickname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string UserPrincipalName { get; set; }

        [JsonProperty("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty("passwordPolicies")]
        public string PasswordPolicies { get; set; }

        [JsonProperty("passwordProfile")]
        public PasswordProfile PasswordProfile { get; set; }
    }

    public class GUIReceivedUserJSONModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }

    public class GUIUserList
    {
        [JsonProperty("batchId")]
        public int BatchId { get; set; }

        [JsonProperty("contacts")]
        public List<GUIReceivedUserJSONModel> GUIReceivedUsersList { get; set; }

    }
}