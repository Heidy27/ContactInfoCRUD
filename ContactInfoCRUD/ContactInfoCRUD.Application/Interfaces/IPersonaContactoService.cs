﻿using ContactInfoCRUD.Application.DTOs;

namespace ContactInfoCRUD.Application.DTOs
{
    public interface IPersonaContactoService
    {
        Task<IEnumerable<PersonaContactoDto>> GetAllContactosByPersonaIdAsync(Guid personaId);
        Task<PersonaContactoDto> GetContactoByIdAsync(Guid id);
        Task<PersonaContactoDto> CreateContactoAsync(CrearPersonaContactoDto contactoDto);
        Task UpdateContactoAsync(Guid id, PersonaContactoDto contactoDto);
        Task DeleteContactoAsync(Guid id);
    }
}
