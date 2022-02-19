using FluentValidation;
using SunstoneProject.Api.Resources.l18n;

namespace SunstoneProject.Api.Controllers.V1.Validations
{
    ///<inheritdoc/>
    public class GemstoneInputValidation : AbstractValidator<InputModels.Gemstone>
    {
        ///<inheritdoc/>
        public GemstoneInputValidation(IMessages messages)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(messages.GetResources("Gestome.Name"));
            RuleFor(x => x.Carat)
                .GreaterThan(0.00M)
                .WithMessage(messages.GetResources("Gestome.Carat"));
            RuleFor(x => x.Clarity)
                .LessThan(100)
                .NotNull()
                .WithMessage(messages.GetResources("Gestome.Clarity"));
            RuleFor(x => x.Color)
                .NotNull()
                .WithMessage(messages.GetResources("Gestome.Color"));
        }
    }
}
