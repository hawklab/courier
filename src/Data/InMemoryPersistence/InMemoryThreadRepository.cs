namespace HawkLab.Data.InMemoryPersistence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;

    public class InMemoryThreadRepository : IThreadRepository
    {
        private readonly List<Thread> threads;

        public InMemoryThreadRepository()
        {
            threads = new List<Thread>()
            {
                new Thread { Id = Guid.Parse("10000000-0000-0000-0000-000000000000"), Subject = "December Projects", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = Guid.Parse("20000000-0000-0000-0000-000000000000"), Subject = "Hawk Lab Ideas", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = Guid.Parse("30000000-0000-0000-0000-000000000000"), Subject = "Home Renovation", Summary = "List of projects we want to finish before Christmas" },
                new Thread { Id = Guid.Parse("40000000-0000-0000-0000-000000000000"), Subject = "2021 Chile Trip", Summary = "List of projects we want to finish before Christmas" },
            };
        }

        public Thread GetById(Guid id)
        {
            return threads.SingleOrDefault(t => t.Id == id);
        }

        public Thread Add(Thread newThread)
        {
            threads.Add(newThread);

            // newThread.Id = threads.Max(r => r.Id) + 1;
            return newThread;
        }

        public Thread Update(Thread updatedThread)
        {
            var thread = threads.SingleOrDefault(t => t.Id == updatedThread.Id);
            if (thread != null)
            {
                thread.Subject = updatedThread.Subject;
                thread.Summary = updatedThread.Summary;
            }

            return thread;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Thread> GetThreadsBySubject(string subject = null)
        {
            return from t in threads
                   where string.IsNullOrEmpty(subject) || t.Subject.StartsWith(subject)
                   orderby t.Subject
                   select t;
        }

        public void Delete(Thread theThread)
        {
            throw new NotImplementedException();
        }
    }
}
