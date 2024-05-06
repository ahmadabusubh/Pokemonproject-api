using Pokemonproject.Model;

namespace WebApplication13.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country country(int id);
        Country Country(string name);
        bool CountryExixt(int id);
        bool creatCountry(Country country);
        bool save();
        bool UPDATECountry(int id, Country Country);
        bool deleteCountry(int id);

    }
}
