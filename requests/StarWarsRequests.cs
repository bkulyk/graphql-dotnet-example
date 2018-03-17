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
            try
            {
                string res = await client.GetStringAsync(url);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
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

        public async Task<Dictionary<string, Person>> GetPeopleIndex(IEnumerable<String> urls)
        {
            var d = new Dictionary<string, Person>();
            var data = JObject.Parse(await getUrl($"https://swapi.co/api/people/"));

            var people = data["results"].Select(x => x.ToObject<Person>());
           
            foreach (var person in people)
            {
                d[person.Url] = person;
            }

            return d;
        }

    }
}
