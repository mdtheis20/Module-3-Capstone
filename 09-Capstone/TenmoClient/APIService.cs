using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using TenmoClient.Data;

namespace TenmoClient
{
    public class APIService
    {

        private readonly static string API_BASE_URL = "https://localhost:44315/";
        private readonly static string ACCOUNTS_URL = API_BASE_URL + "account";
        private readonly IRestClient client = new RestClient();
        private static API_User user = new API_User();

        public APIService(string baseUrl, string token)
        {
            client = new RestClient(baseUrl);
            client.Authenticator = new JwtAuthenticator(token);
        }

        public APIService()
        {
        }

        public bool LoggedIn { get { return !string.IsNullOrWhiteSpace(user.Token); } }

        public string UNAUTHORIZED_MSG { get { return "Authorization is required for this endpoint. Please log in."; } }
        public string FORBIDDEN_MSG { get { return "You do not have permission to perform the requested action"; } }
        public string OTHER_4XX_MSG { get { return "Error occurred - received non-success response: "; } }



        public Account GetBalanceForAccount()
        {
            RestRequest requestOne = new RestRequest(ACCOUNTS_URL);
            IRestResponse<Account> response = client.Get<Account>(requestOne);

            if (response.ResponseStatus != ResponseStatus.Completed || response.IsSuccessful)
            {
                ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }
            return response.Data;
        }


        public string ProcessErrorResponse(IRestResponse response)
        {
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return "Error occurred - unable to reach server.";
            }
            else if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return UNAUTHORIZED_MSG;
                }
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return FORBIDDEN_MSG;
                }
                return OTHER_4XX_MSG + (int)response.StatusCode;
            }
            return "";
        }


        }
    }
