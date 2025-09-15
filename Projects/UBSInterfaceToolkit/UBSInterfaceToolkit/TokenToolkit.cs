using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UBSInterfaceToolkit
{
    public class TokenToolkit
    {
        public const string CLIENT_ID       = "client_id",
                            CLIENT_SECRET   = "client_secret",
                            GRANT_TYPE      = "grant_type",
                            SCOPE           = "scope",
                            ACCESS_TOKEN    = "access_token";


        static public string getToken(string _ubsRootURLAuthentication, string _ubsTenantId, string _ubsEndURLAuthentication, 
                                      string _ubsClientId,string _ubsClientSecret, string _ubsGrantType,string _ubsScope)
        {
            RestResponse        response                  = null;
            RestClientOptions   authenticationUrlRoot     = new RestClientOptions(_ubsRootURLAuthentication) { DisableCharset = true,
                                                                                                               Timeout = TimeSpan.FromMinutes(5)};
            RestClient          completeAuthenticationURL = new RestClient(authenticationUrlRoot);
            RestRequest         request                   = new RestRequest(_ubsTenantId + _ubsEndURLAuthentication, Method.Post);

            request.AddParameter(CLIENT_ID, _ubsClientId);
            request.AddParameter(CLIENT_SECRET, _ubsClientSecret);
            request.AddParameter(GRANT_TYPE, _ubsGrantType);
            request.AddParameter(SCOPE, _ubsScope);

            try
            {
                response = completeAuthenticationURL.Execute(request);
                //Check if the answer is correct and json content is ok
                if (response.IsSuccessful && response.Content != null)
                {
                    // Json deserialisation and get access_Tock
                    var jsonResponse = JObject.Parse(response.Content);
                    string accessToken = jsonResponse[ACCESS_TOKEN]?.ToString();

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        return accessToken;
                    }
                    else
                    {
                        throw new Exception("Access token is not find");
                    }
                }
                else
                {
                    throw new Exception($"Error during API Call: {response.StatusCode} - {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                throw;
            }
        }
    }
}
