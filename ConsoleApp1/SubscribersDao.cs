using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscribers
{
    public class SubscribersDao
    {
        public Subscriber[] data { get; set; }
        public bool success { get; set; }
        public string token { get; set; }
       
    }
}
