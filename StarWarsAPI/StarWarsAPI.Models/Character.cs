using System;
using System.Collections.Generic;

namespace StarWarsAPI.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public List<String> Episodes { get; set; }
        public List<String> Friends { get; set; }
    }
}
