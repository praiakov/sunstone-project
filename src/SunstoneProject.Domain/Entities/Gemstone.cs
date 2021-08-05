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
                throw new DomainException("name cannot be empty or null.");

            if (carat <= 0)
                throw new DomainException("carat cannot be under or equal to zero.");

            if (clarity <= 0)
                throw new DomainException("clarity cannot be under or equal to zero.");

            if (IsColorEnum(color) is false)
                throw new DomainException("color cannot be different from preset colors.");

            Name = name;
            Carat = carat;
            Clarity = clarity;
            Color = color;
        }

        /// <summary>
        /// Solution found in
        /// https://www.oreilly.com/library/view/c-cookbook/0596003390/ch04s04.html
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static bool IsColorEnum(Colors color)
        {
            if ((color & Colors.All) == color)
                return (true);
            else
                return (false);
        }
    }
}
