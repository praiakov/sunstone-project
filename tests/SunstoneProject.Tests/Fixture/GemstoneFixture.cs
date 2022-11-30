using SunstoneProject.Domain.Entities;
using System.Collections.Generic;

namespace SunstoneProject.Tests.Fixture
{
    internal static class GemstoneFixture
    {
        internal static IEnumerable<Gemstone> GetGemstones()
        {
            IEnumerable<Gemstone> gemstones = new List<Gemstone>()
            {
                new Gemstone("Rubi", 10, 10, SunstoneProject.Domain.Enums.Colors.Red)
            };

            return gemstones;
        }

        internal static Gemstone AddGemstone() => new Gemstone("Rubi", 10, 10, SunstoneProject.Domain.Enums.Colors.Red);
        
    }
}
