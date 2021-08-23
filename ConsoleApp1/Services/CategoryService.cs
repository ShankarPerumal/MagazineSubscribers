using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public class CategoryService : ICategoryService
    {
        public List<string> GetCatageories(string token)
        {
            var restapi = new RestClient("http://magazinestore.azurewebsites.net/api");
            var req = new RestRequest("categories/" + token);
            var response = restapi.Execute(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string rawResonse = response.Content;
                Category result = JsonConvert.DeserializeObject<Category>(rawResonse);
                List<string> categories = new List<string>();
                foreach (var obj in result.data)
                {
                    categories.Add(obj);
                }
                return categories;
            }
            return null;
        }
    }
}