using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class CallRepository : EFRepository<Call>, ICallRepository
    {
        public CallRepository(IDbContext dbContext) : base(dbContext)
        {
        }

       
    }
}