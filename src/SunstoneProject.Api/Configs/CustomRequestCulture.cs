using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace SunstoneProject.Api.Configs
{
    ///<inheritdoc/>
    public class CustomRequestCulture : RequestCultureProvider
    {
        ///<inheritdoc/>
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
