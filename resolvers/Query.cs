using GraphQL.Types;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using test.Requests;
using test.Models;

namespace test.Resolvers
{   
    public class Query
    {
        public async Task<Models.Film> Film(ResolveFieldContext context)
        {
            StarWarsRequest r = new StarWarsRequest();
            Models.Film film = await r.GetFilm();
            return film;
        }
    }
}