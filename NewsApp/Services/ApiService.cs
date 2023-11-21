using NewsApp.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ApiService
    {
        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category=general&lang=zh&country=tw&max=10&apikey=42d6b51811093c56fdbfd62c58109aab");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
