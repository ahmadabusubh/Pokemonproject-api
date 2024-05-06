using Pokemonproject.Model;

namespace WebApplication13.Interfaces
{
    public interface PokemonCategoryRepostory
    {
        PokemonCategory GetPokemonCategory(int id);
        ICollection<PokemonCategory> GetPokemonCategories(int id);
        bool creatPokemonCategory(PokemonCategory pokemonCategory);
        bool upditePokemonCategory(int id, PokemonCategory pokemonCategory);
        bool deletePokemonCategory(int id);
        bool existPokemonCategory(int id);
        bool savechage();
    }
}
