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
    public class ServicioStudent
    {
        readonly Conexion conexion;
        readonly IMongoDatabase database;

        public ServicioStudent()
        {
            conexion = new Conexion();
            database = conexion.GetDatabase("Educacion");
        }

        private IMongoCollection<Student> GetCollection()
        {
            return database.GetCollection<Student>("students");
        }

        public bool Login(string email, string password)
        {
            IMongoCollection<Student> collection = GetCollection();
            Student result = IMongoCollectionExtensions.AsQueryable(collection).FirstOrDefault((s) => s.Email == email);

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

        public List<Student> BuscarTodos()
        {
            IMongoCollection<Student> collection = GetCollection();
            var documents = collection.Find(Builders<Student>.Filter.Empty).ToListAsync();

            return documents.Result;
        }

        public bool Agregar(string name, string lastname, string email, string password)
        {
            IMongoCollection<Student> collection = GetCollection();

            Student newStudent = new Student
            {
                Name = name,
                Lastname = lastname,
                Email = email,
                Password = Encryptor.MD5Hash(password),
            };

            try
            {
                collection.InsertOne(newStudent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(string id, string type, string value)
        {
            IMongoCollection<Student> collection = GetCollection();
            ObjectId _id = ObjectId.Parse(id);
            var filter = Builders<Student>.Filter.Eq((s) => s._id, _id);

            try
            {
                if (type == "name")
                {
                    var update = Builders<Student>.Update.Set((s) => s.Name, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                if (type == "lastname")
                {
                    var update = Builders<Student>.Update.Set((s) => s.Lastname, value);
                    collection.UpdateOne(filter, update);
                    return true;
                }

                if (type == "email")
                {
                    var update = Builders<Student>.Update.Set((s) => s.Email, value);
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
            IMongoCollection<Student> collection = GetCollection();
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
