using System;
using System.Collections.Generic;
using System.Text;

namespace ApiProducts.Library.Models
{
    public class UserMin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
    public class User : UserMin
    {
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Jwt { get; set; }
    }
   
}
