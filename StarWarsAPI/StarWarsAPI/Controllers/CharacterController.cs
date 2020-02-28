using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        [HttpGet]
        public List<Character> GetCharacters()
        {
            List<Character> characters = new List<Character>();
            characters.Add(new Character { Name = "John", CharacterId = 1, Episodes = new List<string>(){ "aaa", "ww" }, Friends = new List<string>() { "AS", "zX" } } );
            characters.Add(new Character { Name = "John2", CharacterId = 1, Episodes = new List<string>() { "aaa2", "ww2" }, Friends = new List<string>() { "AS2", "zX2" } });

            return characters;
        }
    }
}