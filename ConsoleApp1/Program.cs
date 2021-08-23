using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using System.Collections;
using System.Web.Script.Serialization;
using MagazineSubscribers.Services;

namespace MagazineSubscribers
{
    class Program
    {
        static void Main(string[] args)
        {
            ISubscriberService subscriberService = new SubscriberService();
            IMagazineService magazineService = new MagazineService();
            ITokenService tokenService = new TokenService();
            ICategoryService categoryService = new CategoryService();
            MagazineSubsribers magazineSubsribers = new MagazineSubsribers(subscriberService, tokenService, magazineService,  categoryService);
            magazineSubsribers.ManageSubscribers();
        }


        

    }
}




