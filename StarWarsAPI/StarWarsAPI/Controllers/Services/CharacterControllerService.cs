using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsAPI.AccessLayer;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers.Services
{
    public class CharacterControllerService
    {
        private StarContext _context;

        public CharacterControllerService(StarContext context)
        {
            this._context = context;
        }
        public List<Character> GetAllCharacters()
        {
            List<Character> characters = _context.Characters.ToList();

            foreach (Character ch in characters)
            {
                ch.Friends = _context.CharaterFriends.Where(chf => chf.CharacterId == ch.Id).Select(chn => chn.Friend.Name).ToList();
                ch.Episodes = _context.CharactersEpisodes.Where(che => che.CharacterId == ch.Id).Select(che => che.Episode.Name).ToList();
            }
            return characters;
        }
        public Character GetCharacterById(int id)
        {
            Character character = _context.Characters.Find(id);
            character.Friends = _context.CharaterFriends.Where(chf => chf.CharacterId == character.Id).Select(chn => chn.Friend.Name).ToList();
            character.Episodes = _context.CharactersEpisodes.Where(che => che.CharacterId == character.Id).Select(che => che.Episode.Name).ToList();

            return character;
        }
    }
}
