﻿namespace Pokemonproject.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategory { get; set; }

    }
}
