using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CharacterEpisode> CharacterEpisodes { get; set; }
    }
}
