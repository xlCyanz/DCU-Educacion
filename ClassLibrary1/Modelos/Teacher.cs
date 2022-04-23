using MongoDB.Bson;

namespace Datos.Modelos
{
    public class Teacher
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
