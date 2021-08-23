using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
namespace MagazineSubscribers
{
    public class RestHelper
    {
       
        public static IRestResponse Post(string baseUrl, string resourceUrl, string json)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(resourceUrl, Method.POST);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return client.Execute(request);
        }

        public static string ConvertObjectToJson<T>(T arg)
        {
            return JsonConvert.SerializeObject(arg);
        }

        public static ResultSubscribers GetResponseObject(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<ResultSubscribers>(response.Content);
        }
    }
}
