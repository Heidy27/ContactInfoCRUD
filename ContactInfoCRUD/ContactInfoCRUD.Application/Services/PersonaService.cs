using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // Obtiene todas las personas en la base de datos
        public async Task<IEnumerable<PersonaDto>> GetAllPersonasAsync()
        {
            var personas = await _personaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(personas);
        }

        // Obtiene una persona por su ID
        public async Task<PersonaDto> GetPersonaByIdAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(persona);
        }

        // Crea una nueva persona en la base de datos
        public async Task<PersonaDto> CreatePersonaAsync(GetPersonaDto personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            await _personaRepository.AddAsync(persona);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonaDto>(persona);
        }

        // Actualiza una persona por su ID
        public async Task UpdatePersonaAsync(int id, PersonaDto personaDto)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            _mapper.Map(personaDto, persona);
            await _personaRepository.UpdateAsync(persona);
            await _unitOfWork.CommitAsync();
        }

        // Elimina una persona por su ID
        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            await _personaRepository.DeleteAsync(persona);
            await _unitOfWork.CommitAsync();
        }

    }
}
