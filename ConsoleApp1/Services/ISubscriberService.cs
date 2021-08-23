using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public interface ISubscriberService
    {
         List<Subscriber> GetSubscribers(string token);

         void FinalSubscriberIds(string token, ResultSubscribers subscribers);
    }
}
