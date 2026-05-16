namespace CampusNet.Models
{
    public class Vertex
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }

        public Vertex(int id, string nombre, string rol)
        {
            Id = id;
            Nombre = nombre;
            Rol = rol;
        }

        public override string ToString()
        {
            return $"{Id} - {Nombre} ({Rol})";
        }
    }
}