using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI.Models
{
    public class CharacterEpisode
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
    }
}
