using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace SunstoneProject.Api.Configs
{
    public class CustomRequestCulture : RequestCultureProvider
    {
        public override async Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            var browserLang = httpContext.Request.Headers["Accept-Language"]
                                         .ToString()
                                         .Split(";")
                                         .FirstOrDefault()?
                                         .Split(",")
                                         .FirstOrDefault();

            return await Task.FromResult(new ProviderCultureResult(browserLang));
        }
    }
}
