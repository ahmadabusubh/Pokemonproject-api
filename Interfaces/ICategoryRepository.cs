using Pokemonproject.Model;
using WebApplication13.dto;

namespace WebApplication13.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> getPokemon();
        Category Getpokemonz(int id);
        Category Getpokemons(string name);
        bool CategoryExist(int idk);
        bool creatCategory(Category category);
        bool UPDATECategory(int id,Category category);
        bool save();
        bool deleteCategory(int id);
    }
}
