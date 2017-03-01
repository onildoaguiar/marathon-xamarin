using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats
{
    public class Repository
    {

        public async Task<List<Cat>> GetCats()
        {
            List<Cat> Cats;
            var URLWebAPI = "http://demos.ticapacitacion.com/cats";
            using (var Client = new System.Net.Http.HttpClient())
            {
                var JSON = await Client.GetStringAsync(URLWebAPI);
                Cats = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cat>>(JSON);
            }
            return Cats;
        }
    }
}
