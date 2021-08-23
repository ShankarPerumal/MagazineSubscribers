using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscribers
{
    public class ResultSubscribers
    {
        public string[] subscribers { get; set; }

        public string totalTime { get; set; }
        public bool answerCorrect { get; set; }
        public object shouldBe { get; set; }
        public string Message { get; set; }
        public string ConfirmationId { get; set; }
        public string Status { get; set; }
    }
}
