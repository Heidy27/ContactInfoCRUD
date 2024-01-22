using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Application.DTOs
{
    public class GetPersonaDto
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public List<GetPersonaContactoDto> Contactos { get; set; }

    }
}
