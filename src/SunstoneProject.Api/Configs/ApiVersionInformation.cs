using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SunstoneProject.Api.Configs
{
    /// <summary>
    /// Api Version Information
    /// </summary>
    public class ApiVersionInformation
    {
        /// <summary>
        /// Api Route Prefix
        /// </summary>
        public const string ApiRoutePrefixDocumentation = "";

        /// <summary>
        /// Api Name
        /// </summary>
        public const string Name = "Sunstone - Plataform APi";

        /// <summary>
        /// Api Description
        /// </summary>
        public const string Description = "Api to manages the gemstone";

        /// <summary>
        /// Contact Uri
        /// </summary>
        public static readonly Uri ContactUri = new Uri("https://praia.dev");

        /// <summary>
        /// Contact Name
        /// </summary>
        public const string ContactName = "Adriano Praia";

        /// /// <summary>
        /// Format Pattern
        /// </summary>
        public const string FormatPattern = "'v'VV";

        /// <summary>
        /// Supported Versions
        /// </summary>
        public static readonly List<ApiVersion> Versions = new()
        {
            new ApiVersion(1, 0)
        };
    }
}
