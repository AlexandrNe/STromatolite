using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Stromatolite.DAL
{
    public interface IUserActivityRepository 
    {
        Task<IEnumerable<UserAccount>> GetActiveUsers();
    }
}