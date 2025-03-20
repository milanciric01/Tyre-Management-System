using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Enums;

namespace TMS.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; } // Navigation property to UserRole

        public ICollection<TyreProduction> TyreProductions { get; set; }

    }

}
