using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public class MagazineService : IMagazineService
    {
        public List<Magazine> GetMagazine(string token, string category)
        {
            var restapi = new RestClient("http://magazinestore.azurewebsites.net/api");
            var req = new RestRequest("magazines/" + token + "/"+ category);
            var response = restapi.Execute(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string rawResonse = response.Content;
                MagazinesDao result = JsonConvert.DeserializeObject<MagazinesDao>(rawResonse);
                List<Magazine> subList = new List<Magazine>();
                foreach (var obj in result.data)
                {
                    subList.Add(obj);
                }
                return subList;
            }
            return null;
        }
    }
}