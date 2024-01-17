using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Application.DTOs
{
    public class CrearPersonaDto
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public List<CrearPersonaContactoDto> Contactos { get; set; }

    }
}
