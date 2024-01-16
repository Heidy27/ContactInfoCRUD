
namespace ContactInfoCRUD.Domain.Entities
{
    public class PersonaContacto
    {
        public int Id { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Dirección { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
