using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace WordsAndCats.Core.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<string>> GetRandomWordsAsync(int count)
        {
            var json = await httpClient.GetStringAsync(string.Format(Constants.WordnikUrl, count, Constants.WordnikApiKey));           
            var jArray = JArray.Parse(json);
            return jArray.Select(jToken => jToken["word"].ToString());
        }

        public async Task<byte[]> GetCatAsync()
        {
            return await httpClient.GetByteArrayAsync(Constants.EdgeCatsUrl + new Random().Next());
        }
    }
}
