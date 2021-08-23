using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazineSubscribers.Services
{
    public interface ICategoryService
    {
        List<string> GetCatageories(string token);
    }
}