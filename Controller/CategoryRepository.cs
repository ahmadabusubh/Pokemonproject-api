using AutoMapper;
using DotNetOpenAuth.InfoCard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemonproject.data;
using Pokemonproject.Model;
using System.Security.Claims;
using WebApplication13.dto;
using WebApplication13.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication13.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;
        private readonly datacontexts dataContext;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper, datacontexts dataContext  )
        {
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        [HttpGet ]
        [Authorize]
        public IActionResult GetCategories()
        {
            
            var categories = _categoryRepository.getPokemon();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        

        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepository.Getpokemonz(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetCategoryByName(string name)
        {
            var category = _categoryRepository.Getpokemons(name);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("Exists/{id}")]
        public IActionResult CheckCategoryExistence(int id)
        {
            var exists = _categoryRepository.CategoryExist(id);

            return Ok(exists);
        }


        [HttpPost]
        public IActionResult creatCategory([FromBody] Categorydto category)
        {
            if (category == null)
            {
                return BadRequest("Category object is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var categorys = mapper.Map<Category>(category);

            var created = _categoryRepository.creatCategory(categorys); 
            if (created)
            {
                return CreatedAtAction("GetCategoryById", new { id = category.Id }, category);
            }
            else
            {
                return StatusCode(500, "Internal server error while creating the category");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UPDATECategory(int id, [FromBody] Categorydto categorydto)
        {

            if (categorydto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var nn = mapper.Map<Category>(categorydto);

            var updated = _categoryRepository.UPDATECategory(id, nn);
            if (updated)
            {

                return Ok("Category updated successfully");

            }
            return NotFound("Category not found");












        }


        [HttpDelete("{id}")]

        public IActionResult deleteCategory(int id) {


       var delete=     _categoryRepository.deleteCategory(id);
            if (delete)
            {

                return Ok("Category is delete successfully");

            }
            return NotFound("Category not delete");



        }



    }

    }

