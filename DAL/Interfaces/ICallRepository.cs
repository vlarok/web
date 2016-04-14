using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface ICallRepository : IEFRepository<Call>
    {
        bool AddCall(Call newCall);
       IQueryable<Call> GetAllCalls(DateTime searchStartDate, DateTime searchEndDate);
    }
}
