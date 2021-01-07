namespace HawkLab.Data.Core.Persistence
{
    using System;
    using System.Collections.Generic;
    using HawkLab.Data.Core.Types;

    public interface IThreadRepository
    {
        Thread GetById(Guid id);

        IEnumerable<Thread> GetThreadsBySubject(string subject = null);

        Thread Update(Thread updatedThread);

        Thread Add(Thread newThread);

        void Delete(Thread theThread);

        int Commit();
    }
}
