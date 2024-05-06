using Pokemonproject.data;
using Pokemonproject.Model;
using WebApplication13.dto;
using WebApplication13.Interfaces;

namespace WebApplication13.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly datacontexts dataContext;

        public CategoryRepository(datacontexts dataContext)
        {
            this.dataContext = dataContext;
        }
        public bool CategoryExist(int idk)
        {
            return dataContext.Category.Any(x => x.Id==idk);
        }

        public ICollection<Category> getPokemon()
        {
            return dataContext.Category.OrderBy(x => x.Id).ToList();

     }

        public Category Getpokemons(string name)
        {
            return dataContext.Category.FirstOrDefault(x => x.Name == name);
        }

        public Category Getpokemonz(int id)
        {
            return dataContext.Category.FirstOrDefault(x => x.Id == id);
        }
        public bool creatCategory(Category Category)
        {
            dataContext.Add(Category);
            return save();
        }

        public bool save()
        {
            var ss = dataContext.SaveChanges();
            return ss > 0 ? true : false;

        }

        public bool UPDATECategory(int id,Category category)
        {
            var findcategory = dataContext.Category.Find(id);
            if (findcategory == null) {
                return false;
            
            }
            findcategory.Name = category.Name;

            dataContext.Update(category);
            return save();
        }


        public bool deleteCategory(int id)
        {

            var findcategory = dataContext.Category.Find(id);
            if (findcategory == null)
            {
                return false;

            }

            dataContext.Category.Remove(findcategory);
            return save();
        }
    }
}

