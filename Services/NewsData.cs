using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NewsApp.Entities;
using Newtonsoft.Json;

namespace NewsApp.Services
{
    public interface INewsData
    {
        Task<NewsDoc[]> GetAll();
        NewsDoc Get(string id);
        void Add(NewsDoc doc);
    }

        public class InMemoryNewsData : INewsData
    {
        private static NewsRoot _messagesInMemory;

        public async Task<NewsDoc[]> GetAll()
        {
            // In order to make it work you need to get a new key from The New York Times API: https://developer.nytimes.com/
            string url = "https://api.nytimes.com/svc/search/v2/articlesearch.json?api-key=000000000000000000";

            var client = new HttpClient();
            var newsData = await client.GetAsync(url);

            var news = await newsData.Content.ReadAsStringAsync();
            var messages = JsonConvert.DeserializeObject<NewsRoot>(news);

            _messagesInMemory = messages;

            return messages.response.docs;
        }

        public NewsDoc Get(string id)
        {
            return _messagesInMemory.response.docs.FirstOrDefault(x => x._id == id);
        }

        public void Add(NewsDoc doc)
        {
            doc._id = Guid.NewGuid().ToString();

            var docs = new List<NewsDoc>(_messagesInMemory.response.docs)
            {
                doc
            };

            _messagesInMemory.response.docs = docs.ToArray();
        }
    }
}