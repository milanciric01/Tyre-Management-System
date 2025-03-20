using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Models;

namespace TMS.Data.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResultDTO> LoginAsync(string username, string password,int userId);
        

    }
}
