using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using idbmongo;
//using Microsoft.Extensions.Configuration;
//using System.Diagnostics;

namespace dbmongo
{

    public class MongoDatabase<T> : IMongoDataBase<T> where T : class, new()
    {
        //var configuration = new Configuration();
        //configuration.Get("MongoDbSettings").AppSettings["ConnectionString"];

        protected  static string connectionString =   "";

        private static IMongoClient server = new MongoClient(connectionString);

        private string collectionName;

        private IMongoDatabase db;

        protected IMongoCollection<T> Collection
        {
            get
            {
                return db.GetCollection<T>(collectionName);
            }
            set
            {
                Collection = value;
            }
        }

        public MongoDatabase(string collection)
        {
            collectionName = collection;

            db = server.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }

        public IMongoQueryable<T> Query
        {
            get
            {
                return Collection.AsQueryable<T>();
            }
            set
            {
                Query = value;
            }
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).SingleOrDefault();
        }


        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).ToList<T>();
        }



        public T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return Collection.FindOneAndUpdate(expression, update, option);
        }

        public void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            Collection.UpdateOne(expression, update);
        }

        public void DeleteOne(Expression<Func<T, bool>> expression)
        {
            Collection.DeleteOne(expression);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOne(item);
        }
    }

}