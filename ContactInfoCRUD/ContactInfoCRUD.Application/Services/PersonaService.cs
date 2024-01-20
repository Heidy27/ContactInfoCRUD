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
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonaDto>(persona);
        }

        public async Task UpdatePersonaAsync(int id, PersonaDto personaDto)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            _mapper.Map(personaDto, persona);
            await _personaRepository.UpdateAsync(persona);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePersonaAsync(int id)
        {
            var persona = await _personaRepository.GetByIdAsync(id);
            await _personaRepository.DeleteAsync(persona);
            await _unitOfWork.CommitAsync();
        }

    }
}
