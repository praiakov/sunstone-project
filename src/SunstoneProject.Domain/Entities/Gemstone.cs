using SunstoneProject.Domain.Common;
using SunstoneProject.Domain.Enums;

namespace SunstoneProject.Domain.Entities
{
    public class Gemstone : BaseEntity
    {
        public string Name { get; private set; }
        public decimal Carat { get; private set; }
        public decimal Clarity { get; private set; }
        public Colors Color { get; private set; }

        public Gemstone(string name, decimal carat, decimal clarity, Colors color)
        {
            Name = name;
            Carat = carat;
            Clarity = clarity;
            Color = color;
        }
    }
}
