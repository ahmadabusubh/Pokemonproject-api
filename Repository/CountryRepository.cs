using Pokemonproject.data;
using Pokemonproject.Model;
using WebApplication13.Interfaces;

namespace WebApplication13.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly datacontexts dataContext;

        public CountryRepository(datacontexts dataContext)
        {
            this.dataContext = dataContext;
        }
        public Country country(int id)
        {
            return dataContext.Country.FirstOrDefault(x => x.Id == id);

        }

        public Country Country(string name)
        {
            return dataContext.Country.FirstOrDefault(x => x.Name == name);
        }

        public bool CountryExixt(int id)
        {
            return dataContext.Country.Any(x => x.Id == id);
        }

        public bool creatCountry(Country country)
        {
            dataContext.Add(country);
            return save();
        }

        public bool deleteCountry(int id)
        {
            var find = dataContext.Country.Find(id);
            dataContext.Country.Remove(find);
            return save();
        }

        public ICollection<Country> GetCountries()
        {
            return dataContext.Country.OrderBy(x => x.Id).ToList();
        }

        public bool save()
        {
            var r = dataContext.SaveChanges();
            return r > 0 ? true : false;
        }

        public bool UPDATECountry(int id, Country Country)
        {
            var find = dataContext.Country.Find(id);
            if (find == null)
            {
                return false;
            }
            find.Name = Country.Name;
            dataContext.Country.Update(find);
            return save();
        }

    }
}
