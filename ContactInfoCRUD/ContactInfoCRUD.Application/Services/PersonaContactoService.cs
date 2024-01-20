using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Interfaces; 
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;


namespace ContactInfoCRUD.Application.Services
{
    public class PersonaContactoService : IPersonaContactoService
    {
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PersonaContactoService(IPersonaContactoRepository personaContactoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _personaContactoRepository = personaContactoRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonaContactoDto>> GetAllContactosByPersonaIdAsync(int personaId)
        {
            var contactos = await _personaContactoRepository.GetByPersonaIdAsync(personaId);
            return _mapper.Map<IEnumerable<PersonaContactoDto>>(contactos);
        }

        public async Task<PersonaContactoDto> GetContactoByIdAsync(int id)
        {
            var contacto = await _personaContactoRepository.GetByIdAsync(id);
            return _mapper.Map<PersonaContactoDto>(contacto);
        }

        public async Task<PersonaContactoDto> CreateContactoAsync(CrearPersonaContactoDto contactoDto)
        {
            var contacto = _mapper.Map<PersonaContacto>(contactoDto);
            await _personaContactoRepository.AddAsync(contacto);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonaContactoDto>(contacto);
        }

        public async Task UpdateContactoAsync(int id, PersonaContactoDto contactoDto)
        {
            var contacto = await _personaContactoRepository.GetByIdAsync(id);
            _mapper.Map(contactoDto, contacto);
            await _personaContactoRepository.UpdateAsync(contacto);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteContactoAsync(int id)
        {
            var contacto = await _personaContactoRepository.GetByIdAsync(id);
            await _personaContactoRepository.DeleteAsync(contacto);
            await _unitOfWork.CommitAsync();
        }
    }
}
