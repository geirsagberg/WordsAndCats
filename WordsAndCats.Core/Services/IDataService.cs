using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace WordsAndCats.Core.Services
{
    public interface IDataService
    {
        Task<IEnumerable<string>> GetRandomWordsAsync(int count);
        Task<byte[]> GetCatAsync();
    }
    
}
