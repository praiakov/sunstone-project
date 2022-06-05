using Microsoft.Extensions.Localization;

namespace SunstoneProject.Api.Resources.l18n
{
    ///<inheritdoc/>
    public class Messages : IMessages
    {
        private readonly IStringLocalizer<Messages> _localizer;

        ///<inheritdoc/>
        public Messages(IStringLocalizer<Messages> localizer)
        {
            _localizer = localizer;
        }

        ///<inheritdoc/>
        public string GetResources(string key)
        {
            var resource = _localizer[key];

            if (resource.ResourceNotFound)
                return _localizer["defaultMessage"];

            return resource;

        }
    }
}
