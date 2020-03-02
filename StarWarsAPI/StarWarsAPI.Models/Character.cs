using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StarWarsAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<string> Friends { get; set; }
        [NotMapped]
        public List<string> Episodes { get; set; }

        [JsonIgnore]
        public IList<CharacterFriend> CharFriends { get; set; }
    }
}
