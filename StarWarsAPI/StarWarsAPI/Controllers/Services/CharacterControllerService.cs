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
        public void AddEpisodes(List<string> episodes, Character character)
        {
            foreach (string name in episodes)
            {
                if (EpisodeExists(name))
                {
                    SaveCharacterEpisodeData(name, character);

                }
                else
                {
                    SaveNewEpisodesData(name);
                    SaveCharacterEpisodeData(name, character);
                }
            }
        }

        public void AddFriends(List<string> namesOfFriends, Character character)
        {
            foreach (string friendName in namesOfFriends)
            {
                if (FriendExists(friendName))
                {
                    SaveCharacterFriendData(friendName, character);
                }
                else
                {
                    _context.Characters.Add(new Character() { Name = friendName });
                    _context.SaveChanges();
                    SaveCharacterFriendData(friendName, character);
                }

            }

        }
        public void SaveNewEpisodesData(string name)
        {
            Episode episode = new Episode() { Name = name };
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }
        public void SaveCharacterEpisodeData(string name, Character character)
        {
            Episode newEpisode = _context.Episodes.Where(n => n.Name.ToUpper() == name.ToUpper()).First();
            Character addedCharacter = _context.Characters.Where(n => n.Name.ToUpper() == character.Name.ToUpper()).First();
            CharacterEpisode charEpi = new CharacterEpisode
            {
                CharacterId = character.Id,
                Episode = newEpisode
            };
            _context.CharactersEpisodes.Add(charEpi);
            _context.SaveChanges();
        }


        public void SaveCharacterFriendData(string friendName, Character character)
        {
            Character addedCharacter = _context.Characters.Where(n => n.Name.ToUpper() == character.Name.ToUpper()).First();
            Character friend = _context.Characters.Where(n => n.Name.ToUpper() == friendName.ToUpper()).First();

            CharacterFriend chf = new CharacterFriend
            {
                Character = addedCharacter,
                Friend = friend
            };
            _context.CharaterFriends.Add(chf);
            _context.SaveChanges();
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
        public void DeleteRelatedFriends(Character character)
        {
            var characterFriends = _context.CharaterFriends.Where(chf => chf.CharacterId == character.Id);
            foreach (var chf in characterFriends)
            {
                _context.CharaterFriends.Remove(chf);
            }
            _context.SaveChanges();
        }
        public void DeleteRelatedEpisodes(Character character)
        {
            var characterEpisodes = _context.CharactersEpisodes.Where(che => che.CharacterId == character.Id);
            foreach (var che in characterEpisodes)
            {
                _context.CharactersEpisodes.Remove(che);
            }
            _context.SaveChanges();
        }
        public void DeleteCharacter(Character character)
        {
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }
        public void AddCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
        public void EditCharacterName(Character characterBeforeEdit, Character characterAfterEdit)
        {
            characterBeforeEdit.Name = characterAfterEdit.Name;
            _context.Characters.Attach(characterBeforeEdit);
            _context.Entry(characterBeforeEdit).Property(x => x.Name).IsModified = true;
            _context.SaveChanges();
        }

        public bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
        public bool EpisodeExists(string episodeName)
        {
            return _context.Episodes.Any(e => e.Name.ToUpper() == episodeName.ToUpper());
        }
        public bool FriendExists(string friendName)
        {
            return _context.Characters.Any(e => e.Name.ToUpper() == friendName.ToUpper());
        }

    }
}

