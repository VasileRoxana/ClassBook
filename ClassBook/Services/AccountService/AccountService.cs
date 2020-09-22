using ClassBook.Repositories.AccountRepository;
using System;

namespace ClassBook.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Guid GetStudentId(Guid userId)
        {
            var studentId = _accountRepository.GetStudentId(userId);

            return studentId;
        }
    }
}
