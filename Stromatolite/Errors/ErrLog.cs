using Stromatolite.DAL;
using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stromatolite.Errors
{
    public class ErrLog
    {
        private DataAccessLayer DAL = new DataAccessLayer();
        public void Log(string message)
        {
            DAL.uof.ErrorLogRepository.Insert(new ErrorLog { ErrorLogID = Guid.NewGuid(), ErrDate = DateTime.UtcNow, ErrDescription = message });
            DAL.uof.Save();
        }
    }
}