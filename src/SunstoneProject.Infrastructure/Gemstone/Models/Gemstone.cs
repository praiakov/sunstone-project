using Newtonsoft.Json;
using SunstoneProject.Domain.Enums;
using System;

namespace SunstoneProject.Infrastructure.Gemstone.Models
{
    public class Gemstone
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("carat")]
        public decimal Carat { get; set; }
        
        [JsonProperty("clarity")]
        public decimal Clarity { get; set; }

        [JsonProperty("color")]
        public Colors Color { get; set; }
    }
}
