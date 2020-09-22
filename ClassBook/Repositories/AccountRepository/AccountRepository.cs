using ClassBook.Models;
using ClassBook.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.AccountRepository
{
    public class AccountRepository : GenericRepository<AppUser>, IAccountRepository
    {
        public AccountRepository(ClassBookDbContext dbContext) : base(dbContext)
        {

        }
        public Guid GetStudentId(Guid userId)
        {
            var user =  _table.AsNoTracking()
                .Where(x => x.Id == userId);

            return user.FirstOrDefault().StudentId;
        }
    }
}
