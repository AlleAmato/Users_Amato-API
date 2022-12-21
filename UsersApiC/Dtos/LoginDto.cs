using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersApiC.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public bool LoginSuccessful { get; set; }
        public string Note { get; set; }

    }
}