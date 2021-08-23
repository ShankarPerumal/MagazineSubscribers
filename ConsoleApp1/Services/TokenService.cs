using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken()
        {
            var restapi = new RestClient("http://magazinestore.azurewebsites.net/api");
            var req = new RestRequest("token");
            var response = restapi.Execute(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string rawResonse = response.Content;
                SubscribersDao result = JsonConvert.DeserializeObject<SubscribersDao>(rawResonse);

                return result.token;
            }
            return null;
        }
    }
}