namespace HawkLab.Data.Core.Types
{
    using System;

    public class Account
    {
        public Guid AccountId { get; init; }

        public string DisplayName { get; set; }

        public string Handle { get; set; }
    }
}
