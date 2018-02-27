using GraphQL.Types;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using test.Requests;
using test.Models;
using System.Linq;
using System.Collections.Generic;

namespace test.Resolvers
{
    public class Person
    {
        public string name(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Name;
        }

        public string height(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Height;
        }

        public string mass(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Mass;
        }

        public string hairColor(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).HairColor;
        }

        public string eyeColor(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).EyeColor;
        }

        public string birthYear(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).BirthYear;
        }

        public string homeworld(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Homeworld;
        }

        public string created(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Created;
        }

        public string edited(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).Edited;
        }

        public string skinColor(ResolveFieldContext context)
        {
            return (context.Source as Models.Person).SkinColor;
        }
    }
}