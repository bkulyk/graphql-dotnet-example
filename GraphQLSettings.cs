﻿using System;
using Microsoft.AspNetCore.Http;

namespace test
{
    public class GraphQLSettings
    {
        public PathString Path { get; set; } = "/graphql";
        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}