namespace Pokemonproject.dto
{
    public class UserWithTokenDto
    {
        public string UserName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string Token { get; set; }
    }
}
