using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.AccessLayer;
using StarWarsAPI.Controllers.Services;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private CharacterControllerService service;

        public CharacterController(StarContext context)
        {

            service = new CharacterControllerService(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            List<Character> characters = service.GetAllCharacters();

            return characters;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = service.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            var characterBeforeEdit = service.GetCharacterById(id);
            if (id != character.Id)
            {
                return BadRequest();
            }
            service.DeleteRelatedFriends(characterBeforeEdit);
            service.DeleteRelatedEpisodes(characterBeforeEdit);
            service.AddEpisodes(character.Episodes, characterBeforeEdit);
            service.AddFriends(character.Friends, characterBeforeEdit);
            service.EditCharacterName(characterBeforeEdit, character);

            return NoContent();
        }
    }
}