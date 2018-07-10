using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stromatolite.Models;
using System.Threading.Tasks;

namespace Stromatolite.DAL
{
    public class UserActivityRepository : IUserActivityRepository
    {
        private DataAccessLayer DAL = new DataAccessLayer();


        public async Task<IEnumerable<UserAccount>> GetActiveUsers()
        {
            IEnumerable<UserAccount> users = await DAL.uof.UserAccountRepository.GetAsync(filter: f => f.LastLogin > UserAccount.ActiveThreshold, orderBy: q => q.OrderByDescending(d => d.LastLogin));
            return users;
        }

    }
}