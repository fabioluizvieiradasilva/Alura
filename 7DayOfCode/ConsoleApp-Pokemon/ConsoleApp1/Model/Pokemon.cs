using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
