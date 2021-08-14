using SunstoneProject.Domain.Enums;

namespace SunstoneProject.Api.Controllers.V1.InputModels
{
    /// <summary>
    /// Corresponds gemstone
    /// </summary>
    public class GemstoneInputModel
    {
        /// <summary>
        /// Gemstone's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gemstone's carat
        /// </summary>
        public decimal Carat { get; set; }

        /// <summary>
        /// Gemstone's clarity
        /// </summary>
        public decimal Clarity { get; set; }

        /// <summary>
        /// Gemstone's color
        /// </summary>
        public Colors Color { get; private set; }
    }
}
