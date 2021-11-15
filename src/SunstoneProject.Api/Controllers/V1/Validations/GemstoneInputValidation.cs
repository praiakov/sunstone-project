using FluentValidation;

namespace SunstoneProject.Api.Controllers.V1.Validations
{
    public class GemstoneInputValidation : AbstractValidator<InputModels.Gemstone>
    {
        public GemstoneInputValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name cannot be null");
            RuleFor(x => x.Carat)
                .GreaterThan(0.00M)
                .WithMessage("Carat cannot be null");
            RuleFor(x => x.Clarity)
                .LessThan(100)
                .NotNull()
                .WithMessage("Clarity cannot be null");
            RuleFor(x => x.Color)
                .NotNull()
                .WithMessage("Color cannot be null");
        }
    }
}
