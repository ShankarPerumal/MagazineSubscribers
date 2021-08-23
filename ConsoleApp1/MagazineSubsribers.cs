using MagazineSubscribers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MagazineSubscribers
{
    public class MagazineSubsribers
    {
        private readonly ISubscriberService _subscriberService;
        private readonly ITokenService _tokenService;
        private readonly IMagazineService _magazines;
        private readonly ICategoryService _categories;

        public MagazineSubsribers(ISubscriberService subscriberService, ITokenService tokenService, IMagazineService magazineService, ICategoryService categoryService)
        {
            _subscriberService = subscriberService;
            _tokenService = tokenService;
            _magazines = magazineService;
            _categories = categoryService;
        }

        public void ManageSubscribers()
        {
            var token =  _tokenService.GetToken();
            List<Subscriber> subscribersList =  _subscriberService.GetSubscribers(token);
            List<string> categoriesList =  _categories.GetCatageories(token);
            List<Magazine> magazinesList = new List<Magazine>();
            Dictionary<int, string> catMagDict = new Dictionary<int, string>();
            int[,] arr = new int[categoriesList.Count, 8];
            List<Subscriber> finalSubList = new List<Subscriber>();
            List<ResultSubscribers> resultSubscribers = new List<ResultSubscribers>();
            ResultSubscribers rs = new ResultSubscribers();
            
            string[] strArray = new string[15];
            int s = 0;
            foreach (string a in categoriesList)
            {
                magazinesList.AddRange(_magazines.GetMagazine(token, a));
            }

            foreach (var magList in magazinesList)
            {
                catMagDict.Add(magList.id, magList.category);

            }

            int sec = 0, fir = 0;

            var first = catMagDict.First();
            var val = first.Value;
            foreach (var n in catMagDict)
            {

                if (val == n.Value)
                {
                    arr[fir, sec] = n.Key;
                    sec++;
                }
                else
                {
                    fir += 1;
                    sec = 0;
                    arr[fir, sec] = n.Key;
                    sec++;
                    val = n.Value;
                }
            }
            bool flag = false;
            int increment = 0;

            for (int i = 0; i < subscribersList.Count; i++)
            {
                for (int k = 0; k < categoriesList.Count; k++)
                {
                    for (int j = 0; j < subscribersList[i].magazineIds.Length; j++)
                    {
                        for (int l = 0; l < subscribersList[i].magazineIds.Length; l++)
                        {
                            if (arr[k, l] != 0 && arr[k, l] == subscribersList[i].magazineIds[j])
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            increment += 1;
                            flag = false;
                            break;
                        }
                    }
                }


                if (categoriesList.Count == increment)
                {
                    Console.WriteLine(subscribersList[i].id);

                    strArray[s] = subscribersList[i].id;
                    s++;
                    resultSubscribers.Add(rs);
                    increment = 0;
                }

                if (increment > 0)
                    increment = 0;
            }
            strArray = strArray.Where(c => c != null).ToArray();
            rs.subscribers = strArray;
            _subscriberService.FinalSubscriberIds(token, rs);
            Console.ReadLine();
        }

        
    }
}
