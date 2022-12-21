using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersApiC.Models;

namespace UsersApiC.Dtos
{//qui creiamo un oggetto con le sembianze di un view model che contiene tutte le proprietà che vanno passate alla vista
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public List<LoginDto> Logins { get; set; }
    }
}