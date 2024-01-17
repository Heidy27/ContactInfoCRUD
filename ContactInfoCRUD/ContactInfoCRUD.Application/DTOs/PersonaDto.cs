
namespace ContactInfoCRUD.Application.DTOs
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public List<PersonaContactoDto> Contactos { get; set; }
    }

}
