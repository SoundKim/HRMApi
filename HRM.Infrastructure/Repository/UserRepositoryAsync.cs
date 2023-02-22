﻿using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repository
{
    public class UserRepositoryAsync: BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        public UserRepositoryAsync(HrmDbContext _context): base(_context)
        {

        }
    }
}
