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

            Field<ListGraphType<PersonType>, IEnumerable<Person>>().Name("characters").ResolveAsync(async (context) => {

                AsyncContext
                var loader = new BatchDataLoader<string, Person>((urls, ct) => {
                    Console.WriteLine("made it into data loader");
                    return r.GetPeopleIndex(/* urls */);
                });

                var chars = new ConcurrentBag<Person>();
                foreach (var url in context.Source.Characters)
                {
                    var person = await loader.LoadAsync(url);
                    chars.Add(person);
                }

                loader.Dispatch();

                return chars;

                //var wedontknow = context.Source.Characters.Select(x => loader.LoadAsync(x).GetAwaiter().GetResult());

                //return wedontknow;

                /*var chars = new ConcurrentBag<Person>();
                Parallel.ForEach(context.Source.Characters, async (url) =>
                {
                    chars.Add(await loader.LoadAsync(url));
                });

                return chars;
                */
            });

            /*Field<ListGraphType<PersonType>>(
                "characters",
                resolve: (context) => {

                    var loader = new BatchDataLoader<string, Person>((urls, ct) => {
                        Console.WriteLine("made it into data loader");
                        return r.GetPeopleIndex();
                    } );

                    var chars = new ConcurrentBag<Person>();
                    Parallel.ForEach(context.Source.Characters, async (url) => 
                    {
                        chars.Add(await loader.LoadAsync(url));
                    });

                    return chars;

                    //return context.Source.Characters.Select(async url => await loader.LoadAsync(url));
                }
            );*/
        }
    }
}
