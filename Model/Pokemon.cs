using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Pokemonproject.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthData { get; set; }
        public ICollection<PokemonCategory> PokemonCategory { get; set; }
        public ICollection<PokemonOwner> PokemonOwner { get; set; }
        public ICollection<Review> Reviews { get; set; }


    }
}
