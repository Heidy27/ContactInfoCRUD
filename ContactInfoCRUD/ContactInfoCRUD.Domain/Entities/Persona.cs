

namespace ContactInfoCRUD.Domain.Entities
{
    public class Persona
    {
        public Persona()
        {
            Contactos = new List<PersonaContacto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public List<PersonaContacto> Contactos { get; set; }
    }
}
