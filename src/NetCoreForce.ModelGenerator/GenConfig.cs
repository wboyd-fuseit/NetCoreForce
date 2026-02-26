using System.Collections.Generic;
using NetCoreForce.Client.Models;
using System.Text.Json.Serialization;

namespace NetCoreForce.ModelGenerator
{
    public class GenConfig
    {
        public AuthInfo AuthInfo { get; set; }

        public string OutputDirectory { get; set; }
        public List<string> Objects { get; set; }
        public string ClassPrefix { get; set; }
        public string ClassSuffix { get; set; }
        public string ClassNamespace { get; set; }
        public bool IncludeCustom { get; set; }
        public bool IncludeReferences { get; set; }

        public GenConfig()
        {
            this.AuthInfo = new AuthInfo(){
                TokenRequestEndpoint = "https://login.salesforce.com/services/oauth2/token",
                ApiVersion = "v64.0"
            };
        }
    }

    //
    // Summary:
    //     Contains login info for the Salesforce API, including OAuth endpoint URLs
    public class AuthInfo
    {
        //
        // Summary:
        //     Client ID, a.k.a. Consumer Key
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        //
        // Summary:
        //     Client Secret, a.k.a. Consumer Secret
        [JsonPropertyName("clientSecret")]
        public string ClientSecret { get; set; }

        //
        // Summary:
        //     Client Secret, a.k.a. Consumer Secret
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

        //
        // Summary:
        //     Salesforce API version
        [JsonPropertyName("apiVersion")]
        public string ApiVersion { get; set; }

        //
        // Summary:
        //     Authorization Endpoint
        //
        //     e.g. https://login.salesforce.com/services/oauth2/authorize
        [JsonPropertyName("authorizationEndpoint")]
        public string AuthorizationEndpoint { get; set; }

        //
        // Summary:
        //     Token request endpoint
        //
        //     e.g. https://login.salesforce.com/services/oauth2/token
        //
        //     Also used for the OAuth refresh roken process
        [JsonPropertyName("tokenRequestEndpoint")]
        public string TokenRequestEndpoint { get; set; }

        //
        // Summary:
        //     OAuth token revocation endpoint
        //
        //     e.g. https://login.salesforce.com/services/oauth2/revoke
        [JsonPropertyName("tokenRevocationEndpoint")]
        public string TokenRevocationEndpoint { get; set; }
    }
}