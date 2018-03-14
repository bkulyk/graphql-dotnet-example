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

        public StarWarsRequest(HttpClient _client) {
            client = _client;
        }

        private async Task<string> getUrl(string url) {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "graphql.net");
            string res = await client.GetStringAsync(url);
            return res;
        }

        public async Task<Film> GetFilm(string id)
        {
            string res = await getUrl($"https://swapi.co/api/films/{id}/");
            return JsonConvert.DeserializeObject<Film>(res);
        }

        public async Task<Person> GetPerson(string id) {
            return await GetPersonWithUrl($"https://swapi.co/api/people/{id}/");
        }

        public async Task<Person> GetPersonWithUrl(string url)
        {
            string res = await getUrl(url);
            return JsonConvert.DeserializeObject<Person>(res);
        }

        public async Task<IEnumerable<Person>> GetPeople(IEnumerable<string> urls)
        {
            var tasks = urls.Select(x => GetPersonWithUrl(x));
            await Task.WhenAll(tasks).ContinueWith(x => x);
            return tasks.Select(x => x.Result);
        }

        public async Task<Dictionary<Tid, T>> GetIndex<Tid, T>(string type)
        {
            System.Console.WriteLine("hi I'm here");
            string res = await getUrl($"https://swapi.co/api/{type}/");
            var data = JObject.Parse(res);

            System.Console.WriteLine(data["count"]);



            return null;
        }

        public async Task<Dictionary<string, Person>> GetPeopleIndex()
        {
            return await GetIndex<string, Person>("people");
        }
    }
}
