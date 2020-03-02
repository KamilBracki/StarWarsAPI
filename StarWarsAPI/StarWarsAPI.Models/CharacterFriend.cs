using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsAPI.Models
{
    public class CharacterFriend
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }


        public int FriendId { get; set; }
        public virtual Character Friend { get; set; }
    }
}
