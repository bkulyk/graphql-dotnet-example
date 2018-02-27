using GraphQL;
using GraphQL.Types;

namespace test
{
    public class TestSchema
    {
        static private string readSchemaFile()
        {
            return string.Join("\n", System.IO.File.ReadAllLines("./schema/schema.graphql"));
        }

        static public ISchema GetSchema()
        {
            return Schema.For(readSchemaFile(), _ => {
                _.Types.Include<Resolvers.Query>();
                _.Types.Include<Resolvers.Film>();
                _.Types.Include<Resolvers.Person>();
            });
        }
    }
}
