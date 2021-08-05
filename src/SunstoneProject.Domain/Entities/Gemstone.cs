using SunstoneProject.Domain.Common;
using SunstoneProject.Domain.Enums;
using SunstoneProject.Domain.Exceptions;

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
            if (string.IsNullOrEmpty(name))
            {
                throw new DomainException("name cannot be empty or null.");
            }

            if (carat <= 0)
            {
                throw new DomainException("carat cannot be under or equal to zero.");
            }

            if (clarity <= 0)
            {
                throw new DomainException("clarity cannot be under or equal to zero.");
            }

            if (color <= 0)
            {
                throw new DomainException("color cannot be under to zero.");
            }

            Name = name;
            Carat = carat;
            Clarity = clarity;
            Color = color;
        }
    }
}
