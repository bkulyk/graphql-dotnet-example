using System;
using System.Collections.Generic;
using test.Models;
using test.Requests;

namespace GraphQL.Types
{
    public class FilmType : ObjectGraphType<Film>
    {
        StarWarsRequest r;

        public FilmType()
        {
            r = new StarWarsRequest(new System.Net.Http.HttpClient());

            Name = "Field";
            Description = "a film in the star wars franchise";

            Field(d => d.Title, nullable: true).Description("Title of the film");

            Field(d => d.EpisodeID, nullable: true).Description("Episode number in StaWars canon.");

            Field(d => d.OpeningCrawl, nullable: true).Description("opening scolling test at the beginning of the film");

            Field(d => d.Director, nullable: true).Description("Director of the film");

            Field(d => d.Producer, nullable: true).Description("Producer of the film");

            Field(d => d.ReleaseDate, nullable: true).Description("Release date of the film");

            Field<ListGraphType<PersonType>>(
                "characters",
                resolve: context => {
                    return r.GetPeople(new List<String>(context.Source.Characters));
                }
            );
        }
    }
}
