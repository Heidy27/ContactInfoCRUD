

namespace ContactInfoCRUD.Application.DTOs
{
    public class GetPersonaContactoDto
    {
        public int Id { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Dirección { get; set; }
        public int PersonaId { get; set; }
    }
}
