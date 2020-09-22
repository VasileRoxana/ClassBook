using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        Guid GetStudentId(Guid userId);
    }
}
