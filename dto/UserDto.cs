﻿namespace Pokemonproject.dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IFormFile ProfilePicture { get; set; }

    }
}
