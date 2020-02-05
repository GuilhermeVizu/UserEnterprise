using System;
using System.Collections.Generic;

namespace CadastroUsuario.Models
{
    public partial class UserEnterprise
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
