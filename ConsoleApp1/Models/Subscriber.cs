using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscribers
{
    public class Subscriber
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int[] magazineIds { get; set; }
        public string[] subscribers { get; set; }
    }
   
}
