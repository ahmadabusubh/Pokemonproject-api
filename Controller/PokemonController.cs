using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemonproject.Model;
using WebApplication13.dto;
using WebApplication13.Interfaces;
using WebApplication13.Repository;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IpokemonRepository _pokemonRepository;
        private readonly IMapper mapper;

        public PokemonController(IpokemonRepository pokemonRepository,IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPokemon()
        {
            var pokemons = _pokemonRepository.getPokemon();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPokemonById(int id)
        {
            var pokemon = _pokemonRepository.Getpokemonz(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetPokemonByName(string name)
        {
            var pokemon = _pokemonRepository.Getpokemons(name);

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpGet("Exists/{id}")]
        public IActionResult CheckPokemonExistence(int id)
        {
            var exists = _pokemonRepository.PokemonExist(id);

            return Ok(exists);
        }

        [HttpPost]
        public IActionResult creatPokemon([FromBody] pokemondtos pokemondtos)
        {
            if (pokemondtos == null)
            {
                return BadRequest("Country object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var maberPokemon = mapper.Map<Pokemon>(pokemondtos);


            var created = _pokemonRepository.creatPokemon(maberPokemon);

            if (created)
            {
                return CreatedAtAction(nameof(GetPokemonById), new { id = pokemondtos.Id }, pokemondtos);
            }
            else
            {
                return StatusCode(500, "Internal server error while creating the country");
            }
        }
        [HttpPut("ahmad/{id}")]
        public IActionResult UPDATEPokemon(int id, [FromBody] pokemondtos pokemondtos)
        {

            if (pokemondtos == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var nn = mapper.Map<Pokemon>(pokemondtos);

            var updated = _pokemonRepository.UPDATEPokemon(id, nn);
            if (updated)
            {

                return Ok("Pokemon updated successfully");

            }
            return NotFound("Pokemon not found");












        }
        [HttpDelete("{id}")]

        public IActionResult deletePokemon(int id) {

      var rr=      _pokemonRepository.deletePokemon(id);
            if (rr) 

                {
                    return Ok("delete is successfully");
                }
            else
                {
                    return NotFound("delte  failed");
                }

            }



        }
    }

