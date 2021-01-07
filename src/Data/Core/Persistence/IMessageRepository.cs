namespace HawkLab.Data.Core.Persistence
{
    using System;
    using System.Collections.Generic;
    using HawkLab.Data.Core.Types;

    public interface IMessageRepository
    {
        // Message GetById(Guid id);
        Message Update(Message updatedMessage);

        Message Add(Message newMessage, Thread aThread);

        void Delete(Message theMessage);

        int Commit();
    }
}
