using GraphQL.Types;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using test.Requests;
using test.Models;
using System.Linq;
using System.Collections.Generic;

namespace test.Resolvers
{   
    public class Film
    {
        public async Task<Models.Person[]> Characters(ResolveFieldContext context)
        {
            Models.Film film = (context.Source as Models.Film);
            List<string> chars = new List<string>(film.Characters).ToList();

            var r = new StarWarsRequest(new System.Net.Http.HttpClient());
            return await r.GetPeople(chars);
        }

        public string title (ResolveFieldContext context) {
            return (context.Source as Models.Film).Title;
        }

        public int episodeID (ResolveFieldContext context) {
            return (context.Source as Models.Film).EpisodeID;
        }

        public string openingCrawl (ResolveFieldContext context) {
            return (context.Source as Models.Film).OpeningCrawl;
        }

        public string director (ResolveFieldContext context) {
            return (context.Source as Models.Film).Director;
        }

        public string producer (ResolveFieldContext context) {
            return (context.Source as Models.Film).Producer;
        }

        public string releaseDate (ResolveFieldContext context) {
            return (context.Source as Models.Film).ReleaseDate;
        }

        public string created (ResolveFieldContext context) {
            return (context.Source as Models.Film).Created;
        }

        public string edited (ResolveFieldContext context) {
            return (context.Source as Models.Film).Edited;
        }
    }
}