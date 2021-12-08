using Microsoft.Extensions.Localization;

namespace SunstoneProject.Api.Resources.l18n
{
    public class Messages : IMessages
    {
        private IStringLocalizer<Messages> _localizer;

        public Messages(IStringLocalizer<Messages> localizer)
        {
            _localizer = localizer;
        }

        public string GetResources(string key)
        {
            var resource = _localizer[key];

            if (resource.ResourceNotFound)
                return _localizer["defaultMessage"];

            return resource;

        }
    }
}
