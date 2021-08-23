using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public interface IMagazineService
    {
        List<Magazine> GetMagazine(string token, string category);
        
    }
}