using System;
using System.Collections.Generic;

using MongoDB.Driver;
using MongoDB.Bson;

using Datos.Modelos;

namespace Datos
{
    public class ServicioTask
    {
        readonly Conexion conexion;
        readonly IMongoDatabase database;

        public ServicioTask()
        {
            conexion = new Conexion();
            database = conexion.GetDatabase("Educacion");
        }

        private IMongoCollection<Task> GetCollection()
        {
            return database.GetCollection<Task>("tasks");
        }

        public List<Task> BuscarTodos()
        {
            IMongoCollection<Task> collection = GetCollection();
            var documents = collection.Find(Builders<Task>.Filter.Empty).ToListAsync();

            return documents.Result;
        }

        public bool Agregar(string name, string descripcion, DateTime limit)
        {
            IMongoCollection<Task> collection = GetCollection();

            Task newTeacher = new Task
            {
                Name = name,
                Description = descripcion,
                DateLimit = limit,
            };

            try
            {
                collection.InsertOne(newTeacher);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(string id, string type, string value)
        {
            IMongoCollection<Task> collection = GetCollection();
            ObjectId _id = ObjectId.Parse(id);
            var filter = Builders<Task>.Filter.Eq((s) => s._id, _id);

            try
            {
                if (type == "name")
                {
                    var update = Builders<Task>.Update.Set((s) => s.Name, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                if (type == "description")
                {
                    var update = Builders<Task>.Update.Set((s) => s.Description, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }

        }

        public bool ActualizarFecha (string id, string type, DateTime value)
        {
            IMongoCollection<Task> collection = GetCollection();
            ObjectId _id = ObjectId.Parse(id);
            var filter = Builders<Task>.Filter.Eq((s) => s._id, _id);

            try
            {
                if (type == "limit")
                {
                    var update = Builders<Task>.Update.Set((s) => s.DateLimit, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Borrar(string id)
        {
            IMongoCollection<Task> collection = GetCollection();
            ObjectId _id = ObjectId.Parse(id);

            try
            {
                collection.DeleteOne((s) => s._id == _id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
