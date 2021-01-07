namespace HawkLab.Data.InMemoryPersistence
{
    using System;
    using System.Collections.Generic;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;

    public class AccountRepository : IAccountRepository
    {
        private static readonly List<Account> AllAccounts = new()
        {
            new Account
            {
                AccountId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                DisplayName = "Jon Doe",
                Handle = "jdoe",
            },
            new Account
            {
                AccountId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                DisplayName = "Sebastian Bach",
                Handle = "sbach",
            },
        };

        public Account Get(string accountId)
        {
            return AllAccounts[0];
        }
    }
}
