﻿using System.ComponentModel.DataAnnotations;

namespace InfinionAPI.DTO
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
