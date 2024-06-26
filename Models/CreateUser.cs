using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InfinionAPI.Models
{
    public class CreateUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
