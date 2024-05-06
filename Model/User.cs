namespace Pokemonproject.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } //تجزئه الباسورد
        public byte[] PasswordSalt { get; set; }//فرز كلمه السر
        public string ProfilePicture { get; set; }

    }
}
