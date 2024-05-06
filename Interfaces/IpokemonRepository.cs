using Pokemonproject.Model;

namespace WebApplication13.Interfaces
{
    public interface IpokemonRepository
    {
        ICollection<Pokemon> getPokemon();
        Pokemon Getpokemonz(int id);
        Pokemon Getpokemons(string name);
        bool PokemonExist(int idk);
        bool creatPokemon(Pokemon Pokemon);
        bool creatPokemon(int OwnerId,int CategoryId, Pokemon Pokemon);
        bool UPDATEpokemon(int id, Pokemon Pokemon);


        bool save();
        bool UPDATEPokemon(int id, Pokemon Pokemon);
        bool deletePokemon(int id);
    }
}
