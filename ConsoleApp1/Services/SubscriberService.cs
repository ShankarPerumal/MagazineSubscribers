using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MagazineSubscribers.Services
{
    public class SubscriberService : ISubscriberService
    {
        public void FinalSubscriberIds(string token, ResultSubscribers subscribers)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(subscribers);

            var response = RestHelper.Post("http://magazinestore.azurewebsites.net/api", "answer/" + token, json);
            System.Console.WriteLine(string.Format("Status Code {0}", response.StatusCode));
            if (response.ErrorMessage != null)
            {
                System.Console.WriteLine(string.Format("Error Message {0}", response.ErrorMessage));
            }
            else if (response.StatusCode.ToString() != "Created")
            {
                System.Console.WriteLine(string.Format("Message {0}", response.Content.ToString()));
            }
            else
            {
                var resObj = RestHelper.GetResponseObject(response);
                System.Console.WriteLine(string.Format("Message: {0}  Id: {1} Status: {2}", resObj.Message, resObj.ConfirmationId, resObj.Status));
            }
        }

        public List<Subscriber> GetSubscribers(string token)
        {
            var restapi = new RestClient("http://magazinestore.azurewebsites.net/api");
            var req = new RestRequest("subscribers/" + token);

            var response = restapi.Execute(req);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string rawResonse = response.Content;
                SubscribersDao result = JsonConvert.DeserializeObject<SubscribersDao>(rawResonse);
                List<Subscriber> subList = new List<Subscriber>();
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
