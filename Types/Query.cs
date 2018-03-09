using System;
using GraphQL.Types;
using test.Requests;

namespace GraphQL.StarWars
{
    public class StarWarsQuery : ObjectGraphType<object>
    {
        StarWarsRequest r;

        public StarWarsQuery()
        {
            r = new StarWarsRequest(new System.Net.Http.HttpClient());

            Name = "Query";

            Field<FilmType>(
                "film",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the film" }
                ),
                resolve: context => { return r.GetFilm(context.GetArgument<string>("id")); } //data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            );

            //Field<CharacterInterface>("hero", resolve: context => data.GetDroidByIdAsync("3"));
            //Field<HumanType>(
            //    "human",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the human" }
            //    ),
            //    resolve: context => data.GetHumanByIdAsync(context.GetArgument<string>("id"))
            //);

            //Func<ResolveFieldContext, string, object> func = (context, id) => data.GetDroidByIdAsync(id);

            //FieldDelegate<DroidType>(
            //    "droid",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
            //    ),
            //    resolve: func
            //);
        }
    }
}