namespace WebApplication13.helper
{
    using AutoMapper;
    using Pokemonproject.Model;
    using System.Security.AccessControl;
    using WebApplication13.dto;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Define your mappings here using CreateMap method
            CreateMap< Categorydto, Category>();
            CreateMap<Categorydto, Category>();

            CreateMap<pokemondtos, Pokemon>();
            CreateMap<Countrydto, Country>();

            CreateMap<PokemonCategorydto, PokemonCategory>();


            // Example:
            // CreateMap<SourceClass, DestinationClass>();
        }
    }

}
