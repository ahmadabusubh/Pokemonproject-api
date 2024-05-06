namespace Pokemonproject.Model
{
    public class Token
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string Value { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
