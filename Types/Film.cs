﻿using System;
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

            Field<ListGraphType<PersonType>, List<Person>>().Name("characters").Resolve((context) => {
                var bag = new ConcurrentBag<Person>();

                // Run within an async context to make sure we won't deadlock
                AsyncContext.Run(async () =>
                {
                    var loader = new BatchDataLoader<string, Person>((urls, ct) =>
                    {
                        Console.WriteLine("in data loader");
                        return r.GetPeopleIndex();
                    });

                    // Start async tasks to load by ID
                    var tasks = context.Source.Characters.Select(x => loader.LoadAsync(x));

                    // Dispatch loading
                    loader.Dispatch();

                    Console.WriteLine("dispatched");

                    // Now await tasks
                    foreach(var t in tasks)
                    {
                        bag.Add(await t);
                        Console.WriteLine("add");
                    }
                });

                return bag.ToList();
            });
        }
    }
}
