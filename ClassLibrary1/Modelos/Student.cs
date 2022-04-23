using System;
using MongoDB.Bson;

namespace Datos.Modelos
{
    public class Student
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
