using System;
using MongoDB.Bson;

namespace Datos.Modelos
{
    public class Task
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateLimit { get; set; }
    }
}
