using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using test.Models;
using test.Requests;
using GraphQL.DataLoader;
using System.Linq;
using System.Collections.Concurrent;
using Nito.AsyncEx;

namespace GraphQL.Types
{
    public class FilmType : ObjectGraphType<Film>
    {
        StarWarsRequest r;

        public FilmType()
        {
            r = new StarWarsRequest(new System.Net.Http.HttpClient());

            Name = "Film";
            Description = "a film in the star wars franchise";

            Field(d => d.Title, nullable: true).Description("Title of the film");

            Field(d => d.EpisodeID, nullable: true).Description("Episode number in StaWars canon.");

            Field(d => d.OpeningCrawl, nullable: true).Description("opening scolling test at the beginning of the film");

            Field(d => d.Director, nullable: true).Description("Director of the film");

            Field(d => d.Producer, nullable: true).Description("Producer of the film");

            Field(d => d.ReleaseDate, nullable: true).Description("Release date of the film");

            Field<ListGraphType<PersonType>, Person[]>().Name("characters").ResolveAsync(async (context) => {
                var loader = new BatchDataLoader<string, Person>(async (urls, ct) => await r.GetPeopleIndex(urls));

                // Start async tasks to load by ID
                var tasks = context.Source.Characters.Select(x => loader.LoadAsync(x)).ToArray();

                // Dispatch loading
                loader.Dispatch();

                var people = await Task.WhenAll(tasks).ContinueWith(x => x.Result);
                return people.Where(x => x != null).ToArray();
            });
        }
    }
}
