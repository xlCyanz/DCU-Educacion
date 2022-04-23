using System;
using MongoDB.Driver;

namespace Datos
{
    public class Conexion
    {
        public MongoClient client;

        public Conexion()
        {
            client = new MongoClient("mongodb://localhost:27017");
        }

        public IMongoDatabase GetDatabase(string name)
        {
            return client.GetDatabase(name);
        }
    }
}
