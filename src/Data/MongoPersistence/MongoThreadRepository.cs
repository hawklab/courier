namespace HawkLab.Data.MongoPersistence
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.Core.Types;
    using Microsoft.VisualBasic;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class MongoThreadRepository : IThreadRepository
    {
        public MongoThreadRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("courier");
            var collection = database.GetCollection<Thread>("threads");
            ThreadCollection = collection;
        }

        public IMongoCollection<Thread> ThreadCollection { get; set; }

        public Thread Add(Thread newThread)
        {
            ThreadCollection.InsertOne(newThread);
            return newThread;
        }

        public int Commit()
        {
            return 0;
        }

        public Thread GetById(Guid id)
        {
            var filter = Builders<Thread>.Filter.Eq("Id", id);
            var document = ThreadCollection.Find(filter).First();
            return document;
        }

        public IEnumerable<Thread> GetThreadsBySubject(string subject = null)
        {
            var documents = ThreadCollection.Find(new BsonDocument()).ToList();
            return documents;
        }

        public Thread Update(Thread updatedThread)
        {
            var filter = Builders<Thread>.Filter.Eq("Id", updatedThread.Id);
            var update = Builders<Thread>.Update.Set("Subject", updatedThread.Subject)
                                                .Set("Summary", updatedThread.Summary);
            ThreadCollection.UpdateOne(filter, update);
            return updatedThread;
        }

        public void Delete(Thread theThread)
        {
            var filter = Builders<Thread>.Filter.Eq("Id", theThread.Id);
            ThreadCollection.DeleteOne(filter);
        }
    }
}