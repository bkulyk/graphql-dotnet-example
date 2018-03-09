using System;
using test.Models;
using test.Requests;

namespace GraphQL.Types
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(d => d.Name, nullable: true).Description("Title of the film");
            Field(d => d.Height, nullable: true).Description("Height of the persion");
            Field(d => d.Mass, nullable: true).Description("The person's phusical mass.");
            Field(d => d.HairColor, nullable: true).Description("Color of the person's hair");
            Field(d => d.SkinColor, nullable: true).Description("Color of ther person's skin");
            Field(d => d.EyeColor, nullable: true).Description("Color of the person's eyes.");
            Field(d => d.BirthYear, nullable: true).Description("Year the person was born.");
            Field(d => d.Homeworld, nullable: true).Description("URL of the homeworld");
            Field(d => d.Created, nullable: true);
            Field(d => d.Edited, nullable: true);
        }
    }
}