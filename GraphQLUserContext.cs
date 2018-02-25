using System.Security.Claims;

namespace test
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}