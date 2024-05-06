using Pokemonproject.data;
using Pokemonproject.Model;
using WebApplication13.Interfaces;

namespace WebApplication13.Repository
{
    public class pokemonRepository : IpokemonRepository
    {
        private readonly datacontexts dataContext;

        public pokemonRepository(datacontexts dataContext)
        {
            this.dataContext = dataContext;
        }
        public ICollection<Pokemon> getPokemon()
        {
            return (dataContext.Pokemon.OrderBy(p => p.Id).ToList());

        }

        public Pokemon Getpokemonz(int id)
        {
            return dataContext.Pokemon.FirstOrDefault(x=>x.Id==id);
        }

        public Pokemon Getpokemons(string name)
        {
            return dataContext.Pokemon.FirstOrDefault(x => x.Name == name);
        }

        public bool PokemonExist(int idk)
        {
            return dataContext.Pokemon.Any(x => x.Id == idk);
        }

        public bool creatPokemon(Pokemon Pokemon)
        {
            dataContext.Pokemon.Add(Pokemon);
            return save();
        }

        public bool save()
        {
            var mm = dataContext.SaveChanges();
            return mm > 0 ? true : false;
        }

        public bool creatPokemon(int OwnerId, int CategoryId, Pokemon Pokemon)
        {
            dataContext.Add(OwnerId);
            dataContext.Add(CategoryId);
            dataContext.Add(Pokemon);
            return save();
        }

        public bool UPDATEpokemon(int id, Pokemon Pokemon)
        {
            throw new NotImplementedException();
        }

        public bool UPDATEPokemon(int id, Pokemon Pokemon)
        {
            var find = dataContext.Pokemon.Find(id);
            if (find == null)
            {
                return false;
            }
            find.Name = Pokemon.Name;
            dataContext.Pokemon.Update(find);
            return save();
        }
        
        public bool UPDATEPokemon(Pokemon Pokemon)
        {
            var find = dataContext.Pokemon.Find(Pokemon.Id);
            if (find == null)
            {
                return false;
            }
            find.Name = Pokemon.Name;
            dataContext.Pokemon.Update(find);
            return save();
        }

        public bool deletePokemon(int id)
        {
          var dee=  dataContext.Pokemon.Find(id);
            dataContext.Pokemon.Remove(dee);
            return save();
        }
    }
}
