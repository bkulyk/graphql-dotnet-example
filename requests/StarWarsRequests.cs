using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using test.Models;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test.Requests
{
    public class StarWarsRequest
    {
        private HttpClient client;

        public StarWarsRequest() {
            client = new HttpClient();
        }

        private async Task<string> getUrl(string url) {
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "graphql.net");
            string res = await client.GetStringAsync(url);
            return res;
        }

        public async Task<Film> GetFilm ()
        {
            string res = await getUrl("https://swapi.co/api/films/1/");
            return JsonConvert.DeserializeObject<Film>(res);
        }

        public async Task<Person> GetPerson (string id) {
            var url = $"https://swapi.co/api/people/{id}/";
            return await GetPersonWithUrl(url);
        }

        public async Task<Person> GetPersonWithUrl(string url)
        {
            string res = await getUrl(url);
            return JsonConvert.DeserializeObject<Person>(res);
        }

        public async Task<Person[]> GetPeople (List<string> urls) {
            var tasks = urls.Select(x => GetPersonWithUrl(x));
            await Task.WhenAll(tasks).ContinueWith(x => x);
            var peeps = tasks.Select(x => x.Result);
            return peeps.ToArray();
        }
    }
}
