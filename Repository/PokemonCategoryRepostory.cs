using Pokemonproject.data;
using Pokemonproject.Model;
using System.Linq;
using WebApplication13.Interfaces;

namespace WebApplication13.Repository
{
    public class PikemanCategoryRepostory : PokemonCategoryRepostory
    {
        private readonly datacontexts dataContext;

        public PikemanCategoryRepostory(datacontexts dataContext)
        {
            this.dataContext = dataContext;
        }
        public bool creatPokemonCategory(PokemonCategory pokemonCategory)
        {
            dataContext.PokemonCategory.Add(pokemonCategory);
            return savechage();
        }

        public bool deletePokemonCategory(int id)
        {
            var f = dataContext.PokemonCategory.Find(id);
            dataContext.PokemonCategory.Remove(f);
            return savechage();
        }

        public bool existPokemonCategory(int id)
        {
            var x = dataContext.PokemonCategory.Any(s => s.PokemonId == id);
            var y = dataContext.PokemonCategory.Any(s => s.CategoryId == id);
            return x && y;

        }

        public ICollection<PokemonCategory> GetPokemonCategories(int id)
        {
            return dataContext.PokemonCategory.OrderBy(p => p.PokemonId).ToList();
        }

        public PokemonCategory GetPokemonCategory(int id)
        {
       var x=    dataContext.PokemonCategory.FirstOrDefault(s => s.PokemonId == id);
       var y=     dataContext.PokemonCategory.FirstOrDefault(s => s.CategoryId==id);
            return x;



        }

        public bool savechage()
        {
            var mm = dataContext.SaveChanges();
            return mm > 0 ? true : false;
        }

        public bool upditePokemonCategory(int id, PokemonCategory pokemonCategory)
        {
            var f = dataContext.PokemonCategory.Find(id);
            f.CategoryId = f.CategoryId;
            f.PokemonId = f.PokemonId;
            dataContext.PokemonCategory.Update(f);
            return savechage();


        }
    }
}
