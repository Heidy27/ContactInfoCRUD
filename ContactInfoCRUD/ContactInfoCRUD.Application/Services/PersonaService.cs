using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;


namespace ContactInfoCRUD.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonaDto>> GetAllPersonasAsync()
        {
            var personas = await _personaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(personas);
        }

        public async Task<PersonaDto> GetPersonaByIdAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task<PersonaDto> CreatePersonaAsync(CrearPersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            await _personaRepository.AddAsync(persona);
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task UpdatePersonaAsync(int id, PersonaDto personaDto)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            _mapper.Map(personaDto, persona);
            await _personaRepository.UpdateAsync(persona);
        }

        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            await _personaRepository.DeleteAsync(persona);
        }
    }
}
