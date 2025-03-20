using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.DTO
{
    public class LogDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Action { get; set; }

        public DateTime ActionDateTime { get; set; }
    }
}
