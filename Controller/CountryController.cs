using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemonproject.Model;
using WebApplication13.dto;
using WebApplication13.Interfaces;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper mapper;

        public CountryController(ICountryRepository countryRepository,IMapper mapper)
        {
            _countryRepository = countryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _countryRepository.country(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetCountryByName(string name)
        {
            var country = _countryRepository.Country(name);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpGet("Exists/{id}")]
        public IActionResult CheckCountryExistence(int id)
        {
            var exists = _countryRepository.CountryExixt(id);

            return Ok(exists);
        }
        [HttpPost]
        public IActionResult CreateCountry([FromBody] Countrydto countrydto)
        {
            if (countrydto == null)
            {
                return BadRequest("Country object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var mabercontre = mapper.Map<Country>(countrydto);


            var created = _countryRepository.creatCountry(mabercontre);

            if (created)
            {
                return CreatedAtAction("GetCountryById", new { id = countrydto.Id }, countrydto);
            }

            else
            {
                return StatusCode(500, "Internal server error while creating the country");
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UPDATECountry(int id, [FromBody] Countrydto countrydto)
        {
            if (countrydto == null )
            {
                return BadRequest("Invalid country object or mismatched ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUpdater = mapper.Map<Country>(countrydto);
            var updated = _countryRepository.UPDATECountry(id, newUpdater);

            if (updated)
            {
                return Ok("Country updated successfully");
            }
            else
            {
                return NotFound("Country not found or update operation failed");
            }
        }
        [HttpDelete("{id}")]

        public IActionResult deleteCountry(int id) {
         var delete=   _countryRepository.deleteCountry(id);
            if (delete) 
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
