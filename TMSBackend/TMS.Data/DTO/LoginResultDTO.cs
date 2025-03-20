using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.DTO
{
    public class LoginResultDTO
    {
        public string Token { get; set; }
        public int UserId { get; set; } // or whatever type your ID is
    }

}
