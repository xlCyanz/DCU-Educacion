using System;
using System.Collections.Generic;
using System.Linq;

using MongoDB.Driver;
using MongoDB.Bson;
using IMongoCollectionExtensions = MongoDB.Driver.IMongoCollectionExtensions;

using Datos.Modelos;
using CryptoLib;

namespace Datos
{
    public class ServicioTeacher
    {
        readonly Conexion conexion;
        readonly IMongoDatabase database;

        public ServicioTeacher()
        {
            conexion = new Conexion();
            database = conexion.GetDatabase("Educacion");
        }

        private IMongoCollection<Teacher> GetCollection()
        {
            return database.GetCollection<Teacher>("teachers");
        }

        public bool Login (string email, string password)
        {
            IMongoCollection<Teacher> collection = GetCollection();
            Teacher result = IMongoCollectionExtensions.AsQueryable(collection).FirstOrDefault((s) => s.Email == email);

            if (result == null)
            {
                return false;
            }

            if (result.Password == Encryptor.MD5Hash(password))
            {
                return true;
            }

            return false;
        }

        public List<Teacher> BuscarTodos()
        {
            IMongoCollection<Teacher> collection = GetCollection();
            var documents = collection.Find(Builders<Teacher>.Filter.Empty).ToListAsync();

            return documents.Result;
        }

        public bool Agregar(string name, string lastname, string email, string password)
        {
            IMongoCollection<Teacher> collection = GetCollection();

            Teacher newTeacher = new Teacher
            {
                Name = name,
                Lastname = lastname,
                Email = email,
                Password = Encryptor.MD5Hash(password),
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
            IMongoCollection<Teacher> collection = GetCollection();
            ObjectId _id = ObjectId.Parse(id);
            var filter = Builders<Teacher>.Filter.Eq((s) => s._id, _id);

            try
            {
                if (type == "name")
                {
                    var update = Builders<Teacher>.Update.Set((s) => s.Name, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                if (type == "lastname")               {
                    var update = Builders<Teacher>.Update.Set((s) => s.Lastname, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                if (type == "email")
                {
                    var update = Builders<Teacher>.Update.Set((s) => s.Email, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                return false;
            } catch
            {
                return false;
            }

        }

        public bool Borrar(string id)
        {
            IMongoCollection<Teacher> collection = GetCollection();
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
