using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cats
{
    public class Repository
    {

        public async Task<List<Cat>> GetCats()
        {
            var Service = new AzureService<Cat>();
            var Items = await Service.GetTable();
            return Items.ToList();
        }

    }
}
