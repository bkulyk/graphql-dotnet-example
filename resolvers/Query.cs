using GraphQL.Types;
using System.Threading.Tasks;
using test.Requests;
using test.Models;
using Microsoft.Extensions.DependencyInjection;

namespace test.Resolvers
{
    public class Query
    {
        StarWarsRequest r;

        public Query() 
        {
            r = new StarWarsRequest(new System.Net.Http.HttpClient());
        }

        public async Task<Models.Film> Film(ResolveFieldContext context)
        {
            var id = context.GetArgument<string>("id");
            Models.Film film = await r.GetFilm(id);
            return film;
        }
    }
}