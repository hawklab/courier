namespace HawkLab.Data.MongoPersistence
{
    using System;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using MongoDB.Driver;

    public class MongoMessageRepository : IMessageRepository
    {
        public Message Add(Message newMessage, Thread aThread)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            var filter = Builders<Thread>
                .Filter.Eq(t => t.Id, aThread.Id);
            var update = Builders<Thread>.Update
            .Push<Message>(t => t.Messages, newMessage);
            collection.FindOneAndUpdate(filter, update);
            return newMessage;
        }

        public int Commit()
        {
            return 0;
        }

        // public Message GetById(Guid id)
        // {

        // }
        public Message Update(Message updatedMessage)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message theMessage)
        {
            throw new NotImplementedException();
        }
    }
}