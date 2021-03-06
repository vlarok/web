﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;
using Domain.Rights;

namespace DAL.Repositories
{
  

    public class GroupRepository : EFRepository<Group>, IGroupRepository
    {
        public GroupRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}