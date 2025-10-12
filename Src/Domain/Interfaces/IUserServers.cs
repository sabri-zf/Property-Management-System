using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{

    /// <summary>
    /// implement interface specified to User 
    /// </summary>
    public interface IUserServers
    {
        // implement the interface on UserRepository
        Task<bool> IsValid_UserNameAndPasswordAsync(ISepecification<User> sepecification);

    }
}
